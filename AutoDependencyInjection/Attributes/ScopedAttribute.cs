using Microsoft.Extensions.DependencyInjection;

namespace AutoDependencyInjection.Attributes;

/// <summary>
/// Marks a class for automatic dependency injection registration with scoped lifetime.
/// </summary>
public sealed class ScopedAttribute : InjectAttribute
{
    public ScopedAttribute() : base(ServiceLifetime.Scoped) { }
}
