namespace DoConnectBackend.Models;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string Role { get; set; } = "User"; // "User" or "Admin"
    public ICollection<Question> Questions { get; set; } = new List<Question>();
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}
