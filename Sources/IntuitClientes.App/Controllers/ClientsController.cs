using IntuitClientes.CrossCutting.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IntuitClientes.App.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {


        private readonly ILogger<ClientsController> _logger;

        public ClientsController(ILogger<ClientsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            throw new NotImplementedException("Update method not implemented");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            throw new NotImplementedException("Update method not implemented");
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody] string name)
        {
            throw new NotImplementedException("Update method not implemented");
        }

        [HttpPost]
        public IActionResult Insert([FromBody] ClientDto client)
        {
            throw new NotImplementedException("Update method not implemented");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ClientDto client)
        {
            throw new NotImplementedException("Update method not implemented");
        }
    }
}
