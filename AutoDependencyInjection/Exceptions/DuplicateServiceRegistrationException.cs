namespace Auto_DependencyInjection.Exceptions;

public class DuplicateServiceRegistrationException : Exception
{
    public DuplicateServiceRegistrationException(Type serviceType, Type implementationType)
        : base($"Service '{serviceType.FullName}' is already registered. " +
               $"Duplicate implementation: '{implementationType.FullName}'.")
    {
    }
}
