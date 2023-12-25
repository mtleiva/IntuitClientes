namespace IntuitClientes.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T> Create(T entity);
        Task Remove(int id);
        Task Update(T entity);

    }
}
