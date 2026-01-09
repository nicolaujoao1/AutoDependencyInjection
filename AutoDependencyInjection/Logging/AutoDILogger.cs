using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Auto_DependencyInjection.Logging;

internal sealed class AutoDILogger : IAutoDILogger
{
    private readonly ILogger _logger;

    public AutoDILogger(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger("AutoDI");
    }

    public void Registered(
        Type serviceType,
        Type implementationType,
        ServiceLifetime lifetime,
        bool multiple)
    {
        if (multiple)
        {
            _logger.LogInformation(
                "[AutoDI] Registered: {Service} -> {Implementation} ({Lifetime}) [MULTIPLE]",
                serviceType.Name,
                implementationType.Name,
                lifetime);
        }
        else
        {
            _logger.LogInformation(
                "[AutoDI] Registered: {Service} -> {Implementation} ({Lifetime})",
                serviceType.Name,
                implementationType.Name,
                lifetime);
        }
    }

    public void Error(string message)
    {
        _logger.LogError("[AutoDI] {Message}", message);
    }
}
