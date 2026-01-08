using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AutoDependencyInjection.Logging;

public static class AutoDependencyInjectionLogger
{
    public static void LogRegistered(
        ILogger? logger,
        Type serviceType,
        Type implementationType,
        ServiceLifetime lifetime,
        bool multiple)
    {
        if (logger == null) return;

        if (multiple)
        {
            logger.LogInformation(
                "[AutoDI] Registered: {Service} -> {Implementation} ({Lifetime}) [MULTIPLE]",
                serviceType.Name,
                implementationType.Name,
                lifetime);
        }
        else
        {
            logger.LogInformation(
                "[AutoDI] Registered: {Service} -> {Implementation} ({Lifetime})",
                serviceType.Name,
                implementationType.Name,
                lifetime);
        }
    }

    public static void LogConcrete(
        ILogger? logger,
        Type implementationType,
        ServiceLifetime lifetime)
    {
        if (logger == null) return;

        logger.LogInformation(
            "[AutoDI] Registered concrete: {Implementation} ({Lifetime})",
            implementationType.Name,
            lifetime);
    }
}
