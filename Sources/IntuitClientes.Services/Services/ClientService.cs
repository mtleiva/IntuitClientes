using AutoMapper;
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
    }
}
