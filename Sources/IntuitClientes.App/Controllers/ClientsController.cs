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
        public async Task<ActionResult<BaseResponseDto<List<ClientDto>>>> GetAll()
        {
            try
            {
                // Implementa la lógica para obtener todos los clientes
                List<ClientDto> clients = await _clientService.GetAllClients();
                return BuildOk(clients);
            }
            catch (Exception ex)
            {
                return BuildError<List<ClientDto>>(ex);
            }
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
        public async Task<ActionResult<BaseResponseDto<List<ClientDto>>>> Search([FromBody] string name)
        {
            try
            {
                // Implementa la lógica para buscar clientes por nombre
                List<ClientDto> clients = await _clientService.SearchClientsByName(name);
                return BuildOk(clients);
            }
            catch (Exception ex)
            {
                return BuildError<List<ClientDto>>(ex);
            }
        }
        [HttpPost]
        public async Task<ActionResult<BaseResponseDto<ClientDto>>> Insert([FromBody] InsertClientDto client)
        {
            try
            {
                // Implementa la lógica para insertar un nuevo cliente
                ClientDto insertedClient = await _clientService.InsertClient(client);
                return BuildOk(insertedClient);
            }
            catch (Exception ex)
            {
                return BuildError<ClientDto>(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponseDto<ClientDto>>> Update(int id, [FromBody] ClientDto client)
        {
            try
            {
                // Implementa la lógica para actualizar un cliente
                ClientDto updatedClient = await _clientService.UpdateClient(id, client);
                return BuildOk(updatedClient);
            }
            catch (Exception ex)
            {
                return BuildError<ClientDto>(ex);
            }
        }
    }
}
