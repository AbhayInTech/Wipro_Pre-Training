using BCrypt.Net;
using DoConnectBackend.Data;
using DoConnectBackend.Dtos;
using DoConnectBackend.Models;
using DoConnectBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoConnectBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly ITokenService _tokens;
    public AuthController(ApplicationDbContext db, ITokenService tokens) { _db = db; _tokens = tokens; }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register(RegisterRequest req)
    {
        if (await _db.Users.AnyAsync(u => u.Username == req.Username))
            return BadRequest("Username already exists.");

        var user = new User
        {
            Username = req.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password),
            Role = string.IsNullOrWhiteSpace(req.Role) ? "User" : req.Role!
        };
        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        var token = _tokens.Create(user);
        return new AuthResponse(token, user.Username, user.Role);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(LoginRequest req)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == req.Username);
        if (user is null || !BCrypt.Net.BCrypt.Verify(req.Password, user.PasswordHash))
            return Unauthorized("Invalid credentials.");

        var token = _tokens.Create(user);

        // Set session
        if (HttpContext != null)
        {
            HttpContext.Session.SetString("userId", user.UserId.ToString());
            HttpContext.Session.SetString("username", user.Username);
            HttpContext.Session.SetString("role", user.Role);
        }

        return new AuthResponse(token, user.Username, user.Role);
    }
}
