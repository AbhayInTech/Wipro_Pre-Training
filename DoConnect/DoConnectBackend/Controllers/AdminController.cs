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

    [HttpGet("rejected/questions")]
    public async Task<object> RejectedQuestions() =>
        await _db.Questions.Where(q => q.Status == "Rejected").ToListAsync();

    [HttpGet("rejected/answers")]
    public async Task<object> RejectedAnswers() =>
        await _db.Answers.Where(a => a.Status == "Rejected").ToListAsync();

    [HttpGet("approved/questions")]
    public async Task<object> ApprovedQuestions() =>
        await _db.Questions.Where(q => q.Status == "Approved").ToListAsync();

    [HttpGet("approved/answers")]
    public async Task<object> ApprovedAnswers() =>
        await _db.Answers.Where(a => a.Status == "Approved").ToListAsync();

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
        var q = await _db.Questions
            .Include(q => q.Answers)
            .FirstOrDefaultAsync(q => q.QuestionId == id);

        if (q is null) return NotFound();

        // Delete all images associated with the question
        var questionImages = await _db.Images.Where(i => i.QuestionId == id).ToListAsync();
        foreach (var image in questionImages)
        {
            _db.Images.Remove(image);
        }

        // Delete all images associated with answers of this question
        foreach (var answer in q.Answers)
        {
            var answerImages = await _db.Images.Where(i => i.AnswerId == answer.AnswerId).ToListAsync();
            foreach (var image in answerImages)
            {
                _db.Images.Remove(image);
            }
        }

        // Delete all answers associated with the question
        foreach (var answer in q.Answers)
        {
            _db.Answers.Remove(answer);
        }

        // Delete the question itself
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

    [HttpGet("total/users")]
    public async Task<int> GetTotalUsers() =>
        await _db.Users.CountAsync();

    [HttpGet("total/questions")]
    public async Task<int> GetTotalQuestions() =>
        await _db.Questions.CountAsync();

    [HttpGet("users")]
    public async Task<object> GetUsers() =>
        await _db.Users.Select(u => new { u.UserId, u.Username, u.Role }).ToListAsync();

    [HttpDelete("user/{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        if (!int.TryParse(id, out var userId)) return BadRequest("Invalid user ID");
        var user = await _db.Users.FindAsync(userId);
        if (user is null) return NotFound();
        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("questions-with-answers-and-users")]
    public async Task<object> GetQuestionsWithAnswersAndUsers()
    {
        var questions = await _db.Questions
            .Include(q => q.User)
            .Include(q => q.Answers)
                .ThenInclude(a => a.User)
            .ToListAsync();

        var result = questions.Select(q => new
        {
            QuestionId = q.QuestionId,
            Title = q.Title,
            Text = q.Text,
            Status = q.Status,
            UserId = q.UserId,
            AskedBy = q.User != null ? new { q.User.UserId, q.User.Username } : null,
            Answers = q.Answers.Select(a => new
            {
                AnswerId = a.AnswerId,
                Text = a.Text,
                Status = a.Status,
                UserId = a.UserId,
                AnsweredBy = a.User != null ? new { a.User.UserId, a.User.Username } : null
            }).ToList()
        });

        return Ok(result);
    }
}
