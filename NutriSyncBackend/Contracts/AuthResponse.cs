namespace NutriSyncBackend.Contracts;

public record AuthResponse(string Email, string Username, string Token);