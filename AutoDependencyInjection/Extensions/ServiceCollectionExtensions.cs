using System.Reflection;
using AutoDependencyInjection.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace AutoDependencyInjection.Extensions;

/// <summary>
/// Extension methods for IServiceCollection
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Automatically registers services marked with [Inject] attribute
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assemblies"></param>
    /// <returns></returns>
    public static IServiceCollection AutoInject(
   this IServiceCollection services,
   params Assembly[] assemblies)
    {


        if (assemblies == null || assemblies.Length == 0)
        {
            assemblies = new[] { Assembly.GetCallingAssembly() };
        }

        var typesWithInject = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t =>
                t.IsClass &&
                !t.IsAbstract &&
                t.GetCustomAttribute<InjectAttribute>() != null
            );

        foreach (var implementationType in typesWithInject)
        {
            var injectAttribute = implementationType
                .GetCustomAttribute<InjectAttribute>()!;

            var interfaces = implementationType.GetInterfaces();

            if (!interfaces.Any())
            {
                services.Add(new ServiceDescriptor(
                    implementationType,
                    implementationType,
                    injectAttribute.Lifetime));
                continue;
            }

            foreach (var serviceType in interfaces)
            {
                services.Add(new ServiceDescriptor(
                    serviceType,
                    implementationType,
                    injectAttribute.Lifetime));
            }
        }

        return services;
    }
}
