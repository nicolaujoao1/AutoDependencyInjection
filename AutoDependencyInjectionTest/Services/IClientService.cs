namespace AutoDependencyInjectionTest.Services;

public interface IClientService
{
    Task<List<string>> GetAllAsync();
}
public interface IAddressService
{
    Task<List<string>> GetAllAsync();
}
