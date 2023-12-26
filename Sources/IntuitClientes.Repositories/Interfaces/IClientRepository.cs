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
        Task<Client> GetClientById(int id);

    }
}
