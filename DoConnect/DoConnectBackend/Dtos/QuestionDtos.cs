namespace DoConnectBackend.Dtos;

public record CreateQuestionRequest(string Title, string Text);
public record AnswerCreateRequest(int QuestionId, string Text);
