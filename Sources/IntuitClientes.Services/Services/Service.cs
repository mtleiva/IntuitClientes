using IntuitClientes.Repositories.Interfaces;
using IntuitClientes.Services.Interfaces;

namespace IntuitClientes.Services.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Create(T entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task Remove(int id)
        {
            await _repository.RemoveAsync(id);
        }

        public async Task Update(T entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
