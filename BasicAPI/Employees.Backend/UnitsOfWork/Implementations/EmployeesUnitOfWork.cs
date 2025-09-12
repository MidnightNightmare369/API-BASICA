using Employees.Backend.Repository.Interfaces;
using Employees.Backend.UnitsOfWork.Interfaces;
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
}