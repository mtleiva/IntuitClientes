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

        public async Task<List<Client>> GetAll()
        {
            try
            {
                List<Client> clients = await _db.Clients.ToListAsync();
                return clients;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Client> GetClientById(int id)
        {
            try
            {
                return await GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(Client clientEntity)
        {
            await CreateAsync(clientEntity);
        }

        public async Task<List<Client>> SearchClientsByName(string name)
        {
            try
            {
                List<Client> clients = await _db.Clients
                    .Where(c => c.Name.Contains(name) || c.LastName.Contains(name))
                    .ToListAsync();
                return clients;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(Client existingClient)
        {
            await UpdateAsync(existingClient);
        }
    }
}
