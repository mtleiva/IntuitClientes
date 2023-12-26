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

        public async Task<List<ClientDto>> GetAllClients()
        {
            try
            {
                List<Client> clients = await _clientRepository.GetAll();
                List<ClientDto> clientDtos = _mapper.Map<List<ClientDto>>(clients);
                return clientDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public async Task<ClientDto> InsertClient(InsertClientDto client)
        {
            try
            {
                Client clientEntity = _mapper.Map<Client>(client);
                await _clientRepository.Insert(clientEntity);
                return _mapper.Map<ClientDto>(clientEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ClientDto>> SearchClientsByName(string name)
        {
            try
            {
                List<Client> clients = await _clientRepository.SearchClientsByName(name);
                List<ClientDto> clientDtos = _mapper.Map<List<ClientDto>>(clients);
                return clientDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ClientDto> UpdateClient(int id, InsertClientDto client)
        {
            try
            {
                Client existingClient = await _clientRepository.GetClientById(id);
                if (existingClient == null)
                {
                    throw new Exception("Cliente no encontrado");
                }

                // Actualizar las propiedades del cliente existente con las del DTO
                _mapper.Map(client, existingClient);

                await _clientRepository.Update(existingClient);

                return _mapper.Map<ClientDto>(existingClient);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
