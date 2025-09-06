namespace DoConnectBackend.Models;

using System.ComponentModel.DataAnnotations;

public class Image
{
    [Key]
    public string ImageID { get; set; } = default!;

    public string Path { get; set; } = default!;
    public string? QuestionId { get; set; }
    public Question? Question { get; set; }
    public string? AnswerId { get; set; }
    public Answer? Answer { get; set; }
}
