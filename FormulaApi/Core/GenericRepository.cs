using FormulaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Core;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected ApiDbContext _context;
    internal DbSet<T> _dbSet;
    protected readonly ILogger _logger;

    public GenericRepository(ApiDbContext context,
    ILogger logger)
    {
        _context=context;
        _logger=logger;
        _dbSet= _context.Set<T>();
    }
    public async Task<bool> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    public async Task<IEnumerable<T>> All()
    {
        return await _dbSet.ToListAsync();
    }

    public Task<bool> Delete(T entity)
    {
        _dbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public async Task<T?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public Task<bool> Update(T entity)
    {
        _dbSet.Update(entity);
        return Task.FromResult(true);
    }
}