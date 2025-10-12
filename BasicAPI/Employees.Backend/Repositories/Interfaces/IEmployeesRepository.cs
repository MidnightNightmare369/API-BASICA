using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Employees.Shared.Responses;
using System.Linq.Expressions;

namespace Employees.Backend.Repository.Interfaces;

public interface IEmployeesRepository
{
    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);

    Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<Employee>> GetByIdAsync(int id);

    Task<ActionResponse<IEnumerable<Employee>>> GetAsync();

    Task<ActionResponse<IEnumerable<Employee>>> GetByNameAsync(Expression<Func<Employee, bool>> predicate);
}