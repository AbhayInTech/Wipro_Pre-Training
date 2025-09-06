using Microsoft.AspNetCore.Http;

namespace DoConnectBackend.Dtos;

public class CreateQuestionRequest
{
    public string Title { get; set; } = "";
    public string Text { get; set; } = "";
    public List<IFormFile> Images { get; set; } = new();
}

public class AnswerCreateRequest
{
    public string QuestionId { get; set; } = "";
    public string Text { get; set; } = "";
    public List<IFormFile> Images { get; set; } = new();
}
