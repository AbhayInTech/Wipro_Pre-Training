using DoConnectBackend.Data;
using DoConnectBackend.Dtos;
using DoConnectBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
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

    [HttpGet("{id}")]
    public async Task<ActionResult<object>> Get(string id)
    {
        var q = await _db.Questions
            .Include(x => x.User).Include(x => x.Answers).ThenInclude(a => a.User)
            .Include(x => x.Images)
            .FirstOrDefaultAsync(x => x.QuestionId == id);

        if (q == null)
            return NotFound();

        // Prevent JSON serialization cycle by returning minimal data
        var result = new
        {
            q.QuestionId,
            q.Title,
            q.Text,
            q.Status,
            User = new { q.User.UserId, q.User.Username },
            Answers = q.Answers.Select(a => new
            {
                a.AnswerId,
                a.Text,
                User = new { a.User.UserId, a.User.Username }
            }).ToList(),
            Images = q.Images.Select(img => new { img.ImageId, img.Path }).ToList()
        };

        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Create([FromForm] CreateQuestionRequest req)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
        var lastQuestion = await _db.Questions.OrderByDescending(q => q.QuestionId).FirstOrDefaultAsync();
        var nextId = lastQuestion != null ? int.Parse(lastQuestion.QuestionId.Substring(1)) + 1 : 1;
        var questionId = "q" + nextId;
        var q = new Question { QuestionId = questionId, Title = req.Title, Text = req.Text, UserId = userId, Status = "Pending" };

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
                q.Images.Add(new Image { Path = "/uploads/" + fileName });
            }
        }

        _db.Questions.Add(q);
        await _db.SaveChangesAsync();

        // Prevent JSON serialization cycle by returning minimal data
        var result = new
        {
            q.QuestionId,
            q.Title,
            q.Text,
            q.Status,
            Images = q.Images.Select(img => new
            {
                img.ImageId,
                Path = img.Path.StartsWith("http") ? img.Path : $"http://localhost:5035{img.Path}"
            }).ToList()
        };

        return CreatedAtAction(nameof(Get), new { id = q.QuestionId }, result);
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
