using IntuitClientes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitClientes.Domain.Context
{
    public class DBContext : DbContext
    {
        public DBContext() { }

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Client> Clients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Data Source=ULTRON;Integrated Security=True;Trust Server Certificate=True";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}