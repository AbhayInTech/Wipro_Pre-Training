using DoConnectBackend.Data;
using DoConnectBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult> Upload([FromForm] IFormFile file, [FromForm] string? questionId, [FromForm] string? answerId)
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

    [HttpGet("{id}/{index?}")]
    public async Task<IActionResult> Get(string id, int index = 0)
    {
        Image? img = null;
        if (id.StartsWith("q"))
        {
            var images = await _db.Images.Where(i => i.QuestionId == id && i.AnswerId == null).OrderBy(i => i.ImageId).ToListAsync();
            if (index >= images.Count) return NotFound();
            img = images[index];
        }
        else if (id.StartsWith("a"))
        {
            var images = await _db.Images.Where(i => i.AnswerId == id && i.QuestionId == null).OrderBy(i => i.ImageId).ToListAsync();
            if (index >= images.Count) return NotFound();
            img = images[index];
        }
        else
        {
            return BadRequest("Invalid ID format. Use question or answer ID with prefix 'q' or 'a'.");
        }

        if (img == null) return NotFound();

        var path = img.Path.StartsWith("/") ? img.Path : "/" + img.Path;
        var fullPath = Path.Combine(_env.WebRootPath, path.TrimStart('/'));
        if (!System.IO.File.Exists(fullPath)) return NotFound();

        var ext = Path.GetExtension(fullPath).ToLowerInvariant();
        var contentType = ext switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            _ => "application/octet-stream"
        };

        var fileBytes = await System.IO.File.ReadAllBytesAsync(fullPath);
        return File(fileBytes, contentType);
    }

    [HttpGet("by-question-or-answer")]
    public async Task<ActionResult<IEnumerable<object>>> GetByQuestionOrAnswer([FromQuery] string? questionId, [FromQuery] string? answerId)
    {
        if (string.IsNullOrEmpty(questionId) && string.IsNullOrEmpty(answerId))
            return BadRequest("Either questionId or answerId must be provided.");

        var query = _db.Images.AsQueryable();

        if (!string.IsNullOrEmpty(questionId))
        {
            // Get images for the question or for answers to the question
            var answerIds = await _db.Answers.Where(a => a.QuestionId == questionId).Select(a => a.AnswerId).ToListAsync();
            query = query.Where(img => img.QuestionId == questionId || answerIds.Contains(img.AnswerId!));
        }

        if (!string.IsNullOrEmpty(answerId))
            query = query.Where(img => img.AnswerId == answerId && img.QuestionId == null);

        var images = await query.Select(img => new { img.ImageId, img.Path, img.QuestionId, img.AnswerId }).ToListAsync();

        return Ok(images);
    }
}
