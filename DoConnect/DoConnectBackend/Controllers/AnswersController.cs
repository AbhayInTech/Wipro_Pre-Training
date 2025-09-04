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
public class AnswersController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    public AnswersController(ApplicationDbContext db) { _db = db; }

    [HttpGet("by-question/{questionId:int}")]
    public async Task<IEnumerable<object>> ByQuestion(int questionId)
    {
        return await _db.Answers
            .Include(a => a.User)
            .Where(a => a.QuestionId == questionId && a.Status == "Approved")
            .Select(a => new { a.AnswerId, a.Text, a.Status, user = a.User!.Username })
            .ToListAsync();
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Create(AnswerCreateRequest req)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
        if (!await _db.Questions.AnyAsync(q => q.QuestionId == req.QuestionId))
            return BadRequest("Invalid question.");

        var ans = new Answer { QuestionId = req.QuestionId, UserId = userId, Text = req.Text, Status = "Pending" };
        _db.Answers.Add(ans);
        await _db.SaveChangesAsync();
        return Ok(ans);
    }
}
