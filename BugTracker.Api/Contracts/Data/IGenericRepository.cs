namespace BugTracker.Api.Contracts.Data;

public interface IGenericRepository<T> where T: class
{
    Task<T> GetByIdAsync(int id);
    Task<T> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<T> SaveAsync();
}