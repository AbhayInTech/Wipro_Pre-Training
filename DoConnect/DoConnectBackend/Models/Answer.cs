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

    public ICollection<Image> Images { get; set; } = new List<Image>();
}
