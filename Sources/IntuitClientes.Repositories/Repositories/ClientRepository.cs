using IntuitClientes.Domain.Context;
using IntuitClientes.Domain.Models;
using IntuitClientes.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitClientes.Repositories.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(DBContext db) : base(db) { }

    }
}
