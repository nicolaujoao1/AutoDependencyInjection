using AutoDependencyInjectionTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoDependencyInjectionTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController(IAddressService addressService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var addresses = await addressService.GetAllAsync();
            return Ok(addresses);
        }
    }
}
