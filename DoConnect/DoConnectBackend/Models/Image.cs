namespace DoConnectBackend.Models;

public class Image
{
    public int ImageId { get; set; }
    public string Path { get; set; } = default!;
    public string? QuestionId { get; set; }
    public Question? Question { get; set; }
    public string? AnswerId { get; set; }
    public Answer? Answer { get; set; }
}
