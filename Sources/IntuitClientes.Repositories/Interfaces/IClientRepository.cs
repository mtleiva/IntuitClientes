using IntuitClientes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitClientes.Repositories.Interfaces
{
    public interface IClientRepository: IRepository<Client>
    {
        Task<List<Client>> GetAll();
        Task<Client> GetClientById(int id);
        Task Insert(Client clientEntity);
        Task<List<Client>> SearchClientsByName(string name);
        Task Update(Client existingClient);
    }
}
