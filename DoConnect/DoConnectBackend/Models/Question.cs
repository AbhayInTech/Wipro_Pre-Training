namespace DoConnectBackend.Models;

public class Question
{
    public string QuestionId { get; set; } = default!;
    public int UserId { get; set; }
    public User? User { get; set; }

    public string Title { get; set; } = default!;
    public string Text { get; set; } = default!;
    public string Status { get; set; } = "Pending"; // Pending/Approved/Rejected

    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    public ICollection<Image> Images { get; set; } = new List<Image>();
}
