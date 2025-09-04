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

    [HttpPost("approve/question/{id:int}")]
    public async Task<IActionResult> ApproveQuestion(int id) =>
        await SetStatusQuestion(id, "Approved");

    [HttpPost("reject/question/{id:int}")]
    public async Task<IActionResult> RejectQuestion(int id) =>
        await SetStatusQuestion(id, "Rejected");

    [HttpPost("approve/answer/{id:int}")]
    public async Task<IActionResult> ApproveAnswer(int id) =>
        await SetStatusAnswer(id, "Approved");

    [HttpPost("reject/answer/{id:int}")]
    public async Task<IActionResult> RejectAnswer(int id) =>
        await SetStatusAnswer(id, "Rejected");

    [HttpDelete("question/{id:int}")]
    public async Task<IActionResult> DeleteQuestion(int id)
    {
        var q = await _db.Questions.FindAsync(id);
        if (q is null) return NotFound();
        _db.Questions.Remove(q);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("answer/{id:int}")]
    public async Task<IActionResult> DeleteAnswer(int id)
    {
        var a = await _db.Answers.FindAsync(id);
        if (a is null) return NotFound();
        _db.Answers.Remove(a);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    private async Task<IActionResult> SetStatusQuestion(int id, string status)
    {
        var q = await _db.Questions.FindAsync(id);
        if (q is null) return NotFound();
        q.Status = status;
        await _db.SaveChangesAsync();
        return Ok();
    }

    private async Task<IActionResult> SetStatusAnswer(int id, string status)
    {
        var a = await _db.Answers.FindAsync(id);
        if (a is null) return NotFound();
        a.Status = status;
        await _db.SaveChangesAsync();
        return Ok();
    }
}
