using DoConnectBackend.Data;
using DoConnectBackend.Dtos;
using DoConnectBackend.Hubs;
using DoConnectBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DoConnectBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswersController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IHubContext<NotificationHub> _hub;
    public AnswersController(ApplicationDbContext db, IHubContext<NotificationHub> hub) { _db = db; _hub = hub; }

    [HttpGet("by-question/{questionId}")]
    public async Task<IEnumerable<object>> ByQuestion(string questionId)
    {
        return await _db.Answers
            .Include(a => a.User)
            //.Include(a => a.Images) // Removed as Images property no longer exists
            .Where(a => a.QuestionId == questionId && a.Status == "Approved")
            .Select(a => new { a.AnswerId, a.Text, a.Status, user = a.User!.Username, ImageIDs = a.ImageIDs })
            .ToListAsync();
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Create([FromForm] AnswerCreateRequest req)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
        if (!await _db.Questions.AnyAsync(q => q.QuestionId == req.QuestionId))
            return BadRequest("Invalid question.");

        var answerId = Guid.NewGuid().ToString();
        var ans = new Answer { AnswerId = answerId, QuestionId = req.QuestionId, UserId = userId, Text = req.Text, Status = "Pending" };

        _db.Answers.Add(ans);
        await _db.SaveChangesAsync();

        // Send notification to admin group about new pending answer
        await _hub.Clients.Group("Admin").SendAsync("ReceiveNotification", "System", $"New pending answer for question ID: {ans.QuestionId}");

        // Handle image uploads
        var uploadsDir = Path.Combine("wwwroot", "uploads");
        if (!Directory.Exists(uploadsDir))
        {
            Directory.CreateDirectory(uploadsDir);
        }

        var imageIDs = new List<string>();

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
                var img = new Image { Path = "/uploads/" + fileName, ImageID = Guid.NewGuid().ToString(), AnswerId = answerId };
                _db.Images.Add(img);
                await _db.SaveChangesAsync();

                // img.ImageID = "i" + img.ImageID.ToString(); // Removed because ImageID is now a GUID string

                imageIDs.Add(img.ImageID);
            }
        }

        ans.ImageIDs = string.Join(',', imageIDs);
        await _db.SaveChangesAsync();
        return Ok(ans);
    }
}
