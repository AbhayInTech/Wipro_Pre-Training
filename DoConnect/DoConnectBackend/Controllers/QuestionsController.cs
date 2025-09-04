using DoConnectBackend.Data;
using DoConnectBackend.Dtos;
using DoConnectBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DoConnectBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    public QuestionsController(ApplicationDbContext db) { _db = db; }

    [HttpGet]
    public async Task<IEnumerable<object>> GetAll([FromQuery] bool includePending = false)
    {
        var q = _db.Questions
            .Include(x => x.User)
            .Where(x => includePending || x.Status == "Approved")
            .OrderByDescending(x => x.QuestionId)
            .Select(x => new { x.QuestionId, x.Title, x.Text, x.Status, user = x.User!.Username });

        return await q.ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<object>> Get(int id)
    {
        var q = await _db.Questions
            .Include(x => x.User).Include(x => x.Answers).ThenInclude(a => a.User)
            .Include(x => x.Images)
            .FirstOrDefaultAsync(x => x.QuestionId == id);

        return q is null ? NotFound() : Ok(q);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Create(CreateQuestionRequest req)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
        var q = new Question { Title = req.Title, Text = req.Text, UserId = userId, Status = "Pending" };
        _db.Questions.Add(q);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = q.QuestionId }, q);
    }

    [HttpGet("search")]
    public async Task<IEnumerable<object>> Search([FromQuery] string q)
    {
        q = q?.Trim() ?? "";
        var data = _db.Questions
            .Where(x => x.Status == "Approved" &&
                        (x.Title.Contains(q) || x.Text.Contains(q)))
            .Select(x => new { x.QuestionId, x.Title, x.Text });

        return await data.ToListAsync();
    }
}
