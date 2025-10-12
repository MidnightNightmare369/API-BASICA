using Employees.Backend.Repository.Interfaces;
using Employees.Backend.UnitsOfWork.Interfaces;
using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Employees.Shared.Responses;
using System.Linq.Expressions;

namespace Employees.Backend.UnitsOfWork.Implementations;

public class EmployeesUnitOfWork : GenericUnitOfWork<Employee>, IEmployeesUnitOfWork
{
    private readonly IEmployeesRepository _repository;

    public EmployeesUnitOfWork(IGenericRepository<Employee> repository, IEmployeesRepository employeeRepo) : base(repository)
    {
        _repository = employeeRepo;
    }

    public async Task<ActionResponse<IEnumerable<Employee>>> GetByNameAsync(Expression<Func<Employee, bool>> predicate)
    {
        return await _repository.GetByNameAsync(predicate);
    }

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _repository.GetTotalRecordsAsync(pagination);

    public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination) => await _repository.GetAsync(pagination);

    public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync() => await _repository.GetAsync();

    public override async Task<ActionResponse<Employee>> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

}