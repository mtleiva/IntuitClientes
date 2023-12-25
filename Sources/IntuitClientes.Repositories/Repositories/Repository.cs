
using IntuitClientes.Domain.Context;
using IntuitClientes.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntuitClientes.Repositories.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DBContext _db;
        internal DbSet<T> dbSet;

        public Repository(DBContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        private async Task<T> GetByIdAsync(int id)
        {
            T? entity = await dbSet.FindAsync(id);
            if (entity == null) throw new Exception("Error GetByIdAsync");

            return entity;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            dbSet.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }

        public bool Safe_Any<Z>(IEnumerable<Z> list)
        {
            if (list == null) return false;
            return list.Any();
        }
    }
}
