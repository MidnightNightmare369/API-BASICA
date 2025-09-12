using Employees.Shared.Responses;
using System.Linq.Expressions;

namespace Employees.Backend.Repository.Interfaces;

public interface IEmployeesRepository <T> where T : class
{
    Task<ActionResponse<IEnumerable<T>>> GetByNameAsync(Expression<Func<T, bool>> predicate);
}