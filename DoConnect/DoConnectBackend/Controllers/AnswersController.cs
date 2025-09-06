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

    [HttpGet("by-question/{questionId}")]
    public async Task<IEnumerable<object>> ByQuestion(string questionId)
    {
        return await _db.Answers
            .Include(a => a.User)
            .Include(a => a.Images)
            .Where(a => a.QuestionId == questionId && a.Status == "Approved")
            .Select(a => new { a.AnswerId, a.Text, a.Status, user = a.User!.Username, images = a.Images })
            .ToListAsync();
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Create([FromForm] AnswerCreateRequest req)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
        if (!await _db.Questions.AnyAsync(q => q.QuestionId == req.QuestionId))
            return BadRequest("Invalid question.");

        var lastAnswer = await _db.Answers.OrderByDescending(a => a.AnswerId).FirstOrDefaultAsync();
        var nextId = lastAnswer != null ? int.Parse(lastAnswer.AnswerId.Substring(1)) + 1 : 1;
        var answerId = "a" + nextId;
        var ans = new Answer { AnswerId = answerId, QuestionId = req.QuestionId, UserId = userId, Text = req.Text, Status = "Pending" };

        // Handle image uploads
        var uploadsDir = Path.Combine("wwwroot", "uploads");
        if (!Directory.Exists(uploadsDir))
        {
            Directory.CreateDirectory(uploadsDir);
        }

        foreach (var file in req.Images)
        {
            if (file.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadsDir, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                ans.Images.Add(new Image { Path = "/uploads/" + fileName });
            }
        }

        _db.Answers.Add(ans);
        await _db.SaveChangesAsync();
        return Ok(ans);
    }
}
