using AutoDependencyInjectionTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoDependencyInjectionTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController(IClientService clientService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clients = await clientService.GetAllAsync();
            return Ok(clients);
        }
    }
}
