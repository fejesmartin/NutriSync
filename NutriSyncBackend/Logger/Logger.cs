namespace NutriSyncBackend.Logger;
using Microsoft.Extensions.Logging;

public class ConsoleLogger : ILogger
{
    private readonly ILogger<ConsoleLogger> _logger;

    public ConsoleLogger(ILogger<ConsoleLogger> logger)
    {
        _logger = logger;
    }

    public void LogInformation(string message)
    {
        _logger.LogInformation($"INFO: {message}");
    }

    public void LogError(string message, Exception ex)
    {
        _logger.LogError(ex,$"ERROR: {message}");
    }
}
