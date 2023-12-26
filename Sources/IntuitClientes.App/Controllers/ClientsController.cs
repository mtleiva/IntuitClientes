using Hasar.MSCoelsa.App.Controllers;
using IntuitClientes.CrossCutting.Dtos;
using IntuitClientes.CrossCutting.Logging;
using IntuitClientes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IntuitClients.App.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : BaseController
    {


        private readonly IClientService _clientService;

        public ClientsController( IClientService clientService, ILog logger) : base(logger)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            throw new NotImplementedException("Update method not implemented");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseDto<ClientDto>>> Get(int id)
        {

            try
            {
                ClientDto clientDto = await _clientService.GetClient(id);

                return BuildOk(clientDto);
            }

            catch (Exception ex)
            {
                return BuildError<ClientDto>(ex);
            }


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
