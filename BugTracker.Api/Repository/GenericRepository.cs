using BugTracker.Api.Contracts.Data;
using BugTracker.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Api.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly BugTrackerDbContext _context;

    public GenericRepository(BugTrackerDbContext context)
    {
        _context = context;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
        {
            // use logger to log the error
            return false; // entity not found return false
        }
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        // AsNoTracking() is used to avoid tracking entities for read-only operations improving performance
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        // AsNoTracking() is used to avoid tracking entities for read-only operations improving performance
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        return entity != null;
    }
}