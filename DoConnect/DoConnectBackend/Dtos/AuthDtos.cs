namespace DoConnectBackend.Dtos;

public record RegisterRequest(string Username, string Password, string? Role = "User");
public record LoginRequest(string Username, string Password);
public record AuthResponse(string Token, string Username, string Role);
