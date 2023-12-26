using IntuitClientes.Domain.Context;
using IntuitClientes.Domain.Models;
using IntuitClientes.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Client> GetClientById(int id)
        {
            try {
                Client? entity = await _db.Clients
                    .FirstOrDefaultAsync(i => i.Id == id);

                if (entity == null) throw new Exception("Cliente no encontrado");

                return entity;
            }catch (Exception ex)
            {
                throw;
            }
    } }
}
