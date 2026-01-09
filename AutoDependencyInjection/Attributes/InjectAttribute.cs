using Microsoft.Extensions.DependencyInjection;

namespace Auto_DependencyInjection.Attributes;
/// <summary>
/// Marks a class for automatic dependency injection registration.
/// </summary>

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class InjectAttribute : Attribute
{
    /// <summary>
    /// The lifetime of the service to be registered.
    /// </summary>
    public ServiceLifetime Lifetime { get; }
    /// <summary>
    /// Initializes a new instance of the <see cref="InjectAttribute"/> class with the specified service lifetime.
    /// </summary>
    /// <param name="lifetime"></param>
    public InjectAttribute(ServiceLifetime lifetime)
    {
        Lifetime = lifetime;
    }
}
