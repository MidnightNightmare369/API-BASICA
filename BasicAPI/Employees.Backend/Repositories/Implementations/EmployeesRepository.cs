using Employees.Shared.Responses;
using Employees.Shared.Entities;
using Employees.Backend.Data;
using Employees.Backend.Repository.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Employees.Backend.Repository.Implementations;

public class EmployeesRepository : GenericRepository<Employee>, IEmployeesRepository<Employee>
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
        if (x == null || x.Count == 0)
        {
            return new ActionResponse<IEnumerable<Employee>>
            {
                Message = "No employees found whose name contains the text section sent.",
                WasSuccess = true,
                Result = x
            };
        }

        return new ActionResponse<IEnumerable<Employee>>
        {
            WasSuccess = true,
            Result = x
        };
    }
}