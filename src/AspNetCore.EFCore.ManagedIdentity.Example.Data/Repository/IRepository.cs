namespace AspNetCore.CRUD.Example.Data.Repository;

public interface IRepository<T>
{
    Task<List<T>> GetAllAsync();

    Task<T> GetByIdAsync(int id);

    Task<T> InsertAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task<T> DeleteAsync(T entity);

    Task<T> FindById(int id);
}
