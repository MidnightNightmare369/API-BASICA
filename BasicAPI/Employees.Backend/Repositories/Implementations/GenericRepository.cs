using Employees.Backend.Data;
using Employees.Backend.Repository.Interfaces;
using Employees.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Employees.Backend.Repository.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DataContext _context;
    private readonly DbSet<T> _entity;

    public GenericRepository(DataContext context)
    {
        _context = context;
        _entity = context.Set<T>();
    }

    public async Task<ActionResponse<T>> AddAsync(T entity)
    {
        try
        {
            _entity.Add(entity);
            await _context.SaveChangesAsync();
            return new ActionResponse<T>
            {
                WasSuccess = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return new ActionResponse<T>
            { Message = "The log you tried to create already exists in the database." }; ;
        }
        catch (Exception ex)
        {
            return new ActionResponse<T>
            { Message = ex.Message };
        }
    }

    public async Task<ActionResponse<T>> DeleteAsync(int id)
    {
        var row = await _entity.FindAsync(id);
        if (row == null)
        {
            return new ActionResponse<T>
            { Message = "The log you tried to delete does not exist in the database." };
        }

        try
        {
            _entity.Remove(row);
            await _context.SaveChangesAsync();
            return new ActionResponse<T>
            {
                WasSuccess = true
            };
        }
        catch
        {
            return new ActionResponse<T>
            { Message = "The log you tried to delete is related to another table." };
        }
    }

    public async Task<ActionResponse<IEnumerable<T>>> GetAsync()
    {
        var row = await _entity.ToListAsync();
        return new ActionResponse<IEnumerable<T>>
        {
            WasSuccess = true,
            Result = row
        };
    }

    public async Task<ActionResponse<T>> GetByIdAsync(int id)
    {
        var row = await _entity.FindAsync(id);

        if (row == null)
        {
            return new ActionResponse<T>
            { Message = "The requested log does not exist in the database." };
        }

        return new ActionResponse<T>
        {
            WasSuccess = true,
            Result = row
        };
    }

    public async Task<ActionResponse<T>> UpdateAsync(T entity)
    {
        try
        {
            _entity.Update(entity);
            await _context.SaveChangesAsync();
            return new ActionResponse<T>
            {
                WasSuccess = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return new ActionResponse<T>
            { Message = "The log you tried to update does not exists in the database." };
        }
        catch (Exception ex)
        {
            return new ActionResponse<T>
            { Message = ex.Message };
        }
    }
}