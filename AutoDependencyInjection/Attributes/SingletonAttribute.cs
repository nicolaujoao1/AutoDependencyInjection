using Microsoft.Extensions.DependencyInjection;

namespace AutoDependencyInjection.Attributes;

/// <summary>
/// Marks a class for automatic dependency injection registration with singleton lifetime.  
/// </summary>
public sealed class SingletonAttribute : InjectAttribute
{
    public SingletonAttribute() : base(ServiceLifetime.Singleton) { }
}
