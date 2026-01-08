using Microsoft.Extensions.DependencyInjection;

namespace AutoDependencyInjection.Attributes;

/// <summary>
/// Marks a class for automatic dependency injection registration with transient lifetime.
/// </summary>
public sealed class TransientAttribute : InjectAttribute
{
    public TransientAttribute() : base(ServiceLifetime.Transient) { }
}
