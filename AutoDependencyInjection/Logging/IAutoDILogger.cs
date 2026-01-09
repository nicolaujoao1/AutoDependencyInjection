using Microsoft.Extensions.DependencyInjection;

namespace Auto_DependencyInjection.Logging;

public interface IAutoDILogger
{
    void Registered(
        Type serviceType,
        Type implementationType,
        ServiceLifetime lifetime,
        bool multiple);

    void Error(string message);
}
