using AutoMapper;
using IntuitClientes.CrossCutting.Dtos;
using IntuitClientes.Domain.Models;
using IntuitClientes.Repositories.Interfaces;
using IntuitClientes.Services.Interfaces;

namespace IntuitClientes.Services.Services
{
    public class ClientService : Service<Client>, IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;


        public ClientService(
            IClientRepository clientRepository,

            IMapper mapper) : base(clientRepository)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientDto> GetClient(int id)
        {
            try
            {
                Client client = await _clientRepository.GetClientById(id);
                ClientDto clientDto = _mapper.Map<ClientDto>(client);
                return clientDto;
            }catch (Exception ex) { throw ex; }
        }
    }
}
