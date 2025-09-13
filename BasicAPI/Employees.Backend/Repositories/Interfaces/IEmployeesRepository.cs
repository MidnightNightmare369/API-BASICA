using Employees.Shared.Entities;
using Employees.Shared.Responses;
using System.Linq.Expressions;

namespace Employees.Backend.Repository.Interfaces;

public interface IEmployeesRepository
{
    Task<ActionResponse<IEnumerable<Employee>>> GetByNameAsync(Expression<Func<Employee, bool>> predicate);
}