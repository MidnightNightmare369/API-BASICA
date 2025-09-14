using Employees.Backend.Data;
using Employees.Shared.Entities;
using Employees.Backend.Repository.Interfaces;
using Employees.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Employees.Backend.Repository.Implementations;

public class EmployeesRepository : GenericRepository<Employee>, IEmployeesRepository
{
    private readonly DataContext _context;
    private readonly DbSet<Employee> _entity;

    public EmployeesRepository(DataContext context) : base(context)
    {
        _context = context;
        _entity = context.Set<Employee>();
    }

    public async Task<ActionResponse<IEnumerable<Employee>>> GetByNameAsync(Expression<Func<Employee, bool>> predicate)
    {
        var x = await _entity.Where(predicate).ToListAsync();
        return new ActionResponse<IEnumerable<Employee>>
        {
            WasSuccess = true,
            Result = x
        };
    }
}