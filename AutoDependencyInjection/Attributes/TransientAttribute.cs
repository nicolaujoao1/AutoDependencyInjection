using Microsoft.Extensions.DependencyInjection;

namespace Auto_DependencyInjection.Attributes;

/// <summary>
/// Marks a class for automatic dependency injection registration with transient lifetime.
/// </summary>
public sealed class TransientAttribute : InjectAttribute
{
    public TransientAttribute() : base(ServiceLifetime.Transient) { }
}
