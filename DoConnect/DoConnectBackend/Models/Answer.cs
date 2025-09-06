namespace DoConnectBackend.Models;

public class Answer
{
    public string AnswerId { get; set; } = default!;
    public string QuestionId { get; set; } = default!;
    public Question? Question { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    public string Text { get; set; } = default!;
    public string Status { get; set; } = "Pending"; // Pending/Approved/Rejected

    // New property to store comma-separated image IDs like "i1,i2"
    public string? ImageIDs { get; set; }
}
