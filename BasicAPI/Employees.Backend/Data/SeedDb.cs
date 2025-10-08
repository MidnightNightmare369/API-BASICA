using Employees.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employees.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckFullEmployeesAsync();
    }

    private async Task CheckFullEmployeesAsync()
    {
        if (!_context.Employees.Any())
        {
            _context.Database.SetCommandTimeout(300); // Añadi esta linea ya que mi pc tarda mucho en cargar y arroja error timeout
            var employeesSQLScript = File.ReadAllText("Data\\50InitialEmployees.sql");
            await _context.Database.ExecuteSqlRawAsync(employeesSQLScript);
        }
    }
}