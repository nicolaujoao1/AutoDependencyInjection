using Microsoft.Extensions.DependencyInjection;

namespace Auto_DependencyInjection.Internal;

internal static class ServiceCollectionHelper
{
    public static bool IsServiceRegistered(
        IServiceCollection services,
        Type serviceType)
    {
        return services.Any(sd => sd.ServiceType == serviceType);
    }
}
