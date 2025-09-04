using DoConnectBackend.Data;
using DoConnectBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoConnectBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImagesController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IWebHostEnvironment _env;
    public ImagesController(ApplicationDbContext db, IWebHostEnvironment env) { _db = db; _env = env; }

    [Authorize]
    [HttpPost("upload")]
    public async Task<ActionResult> Upload([FromForm] IFormFile file, [FromForm] int? questionId, [FromForm] int? answerId)
    {
        if (file is null || file.Length == 0) return BadRequest("No file.");
        var uploads = Path.Combine(_env.WebRootPath, "uploads");
        Directory.CreateDirectory(uploads);

        var name = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
        var full = Path.Combine(uploads, name);
        using var fs = System.IO.File.Create(full);
        await file.CopyToAsync(fs);

        var img = new Image { Path = $"/uploads/{name}", QuestionId = questionId, AnswerId = answerId };
        _db.Images.Add(img);
        await _db.SaveChangesAsync();

        return Ok(img);
    }
}
