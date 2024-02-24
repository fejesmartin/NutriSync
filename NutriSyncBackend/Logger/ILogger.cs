namespace NutriSyncBackend.Logger;

public interface ILogger
{
    void LogInformation(string message);
    void LogError(string message, Exception ex);
}
