using Employees.Backend.Repository.Interfaces;
using Employees.Backend.UnitsOfWork.Interfaces;
using Employees.Shared.Responses;

namespace Employees.Backend.UnitsOfWork.Implementations;

public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
{
    private readonly IGenericRepository<T> _repository;

    public GenericUnitOfWork(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<ActionResponse<T>> AddAsync(T entity)
    {
        return await _repository.AddAsync(entity);
    }

    public async Task<ActionResponse<T>> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<ActionResponse<IEnumerable<T>>> GetAsync()
    {
        return await _repository.GetAsync();
    }

    public async Task<ActionResponse<T>> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<ActionResponse<T>> UpdateAsync(T entity)
    {
        return await _repository.UpdateAsync(entity);
    }
}