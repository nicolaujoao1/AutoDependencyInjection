
using AutoDependencyInjection.Attributes;

namespace AutoDependencyInjectionTest.Services
{
    [Inject(ServiceLifetime.Transient)]
    public class ClientService : IClientService
    {
        public async Task<List<string>> GetAllAsync()
        {
            return await Task.FromResult(new List<string>
            {
                "Client 1",
                "Client 2",
                "Client 3"
            });
        }
    }
    [Scoped]
    public class AddressService : IAddressService
    {
        public async Task<List<string>> GetAllAsync()
        {
            return await Task.FromResult(new List<string>
            {
                "Luanda",
                "Benguela",
                "Uige"
            });
        }
    }
}
