using DoConnectBackend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoConnectBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    public AdminController(ApplicationDbContext db) { _db = db; }

    [HttpGet("pending/questions")]
    public async Task<object> PendingQuestions() =>
        await _db.Questions.Where(q => q.Status == "Pending").ToListAsync();

    [HttpGet("pending/answers")]
    public async Task<object> PendingAnswers() =>
        await _db.Answers.Where(a => a.Status == "Pending").ToListAsync();

    [HttpPost("approve/question/{id}")]
    public async Task<IActionResult> ApproveQuestion(string id) =>
        await SetStatusQuestion(id, "Approved");

    [HttpPost("reject/question/{id}")]
    public async Task<IActionResult> RejectQuestion(string id) =>
        await SetStatusQuestion(id, "Rejected");

    [HttpPost("approve/answer/{id}")]
    public async Task<IActionResult> ApproveAnswer(string id) =>
        await SetStatusAnswer(id, "Approved");

    [HttpPost("reject/answer/{id}")]
    public async Task<IActionResult> RejectAnswer(string id) =>
        await SetStatusAnswer(id, "Rejected");

    [HttpDelete("question/{id}")]
    public async Task<IActionResult> DeleteQuestion(string id)
    {
        var q = await _db.Questions.FindAsync(id);
        if (q is null) return NotFound();
        _db.Questions.Remove(q);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("answer/{id}")]
    public async Task<IActionResult> DeleteAnswer(string id)
    {
        var a = await _db.Answers.FindAsync(id);
        if (a is null) return NotFound();
        _db.Answers.Remove(a);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    private async Task<IActionResult> SetStatusQuestion(string id, string status)
    {
        var q = await _db.Questions.FindAsync(id);
        if (q is null) return NotFound();
        q.Status = status;
        await _db.SaveChangesAsync();
        return Ok();
    }

    private async Task<IActionResult> SetStatusAnswer(string id, string status)
    {
        var a = await _db.Answers.FindAsync(id);
        if (a is null) return NotFound();
        a.Status = status;
        await _db.SaveChangesAsync();
        return Ok();
    }
}
