using IntuitClientes.CrossCutting.Dtos;
using IntuitClientes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitClientes.Services.Interfaces
{
    public interface IClientService: IService<Client> 
    {
        Task<List<ClientDto>> GetAllClients();
        Task<ClientDto> GetClient(int id);
        Task<ClientDto> InsertClient(InsertClientDto client);
        Task<List<ClientDto>> SearchClientsByName(string name);
        Task<ClientDto> UpdateClient(int id, ClientDto client);
    }
}
