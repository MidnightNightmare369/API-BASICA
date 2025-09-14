using Employees.Shared.Entities;

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
        await CheckEmployeesAsync();
    }

    private async Task CheckEmployeesAsync()
    {
        if (!_context.Employees.Any())
        {
            _context.Employees.Add(new Employee
            { FirstName = "Juan", LastName = "Barrera", HireDate = DateTime.UtcNow, IsActive = true, Salary = 1000000 });

            _context.Employees.Add(new Employee
            { FirstName = "Ana", LastName = "Gómez", HireDate = DateTime.UtcNow, IsActive = true, Salary = 1800000 });

            _context.Employees.Add(new Employee
            { FirstName = "Carlos", LastName = "Martínez", HireDate = DateTime.UtcNow, IsActive = false, Salary = 2000000 });

            _context.Employees.Add(new Employee
            { FirstName = "Luisa", LastName = "Fernández", HireDate = DateTime.UtcNow, IsActive = true, Salary = 2200000 });

            _context.Employees.Add(new Employee
            { FirstName = "Andrés", LastName = "Rodríguez", HireDate = DateTime.UtcNow, IsActive = true, Salary = 2500000 });

            _context.Employees.Add(new Employee
            { FirstName = "Marta", LastName = "Jiménez", HireDate = DateTime.UtcNow, IsActive = false, Salary = 1700000 });

            _context.Employees.Add(new Employee
            { FirstName = "Sofía", LastName = "López", HireDate = DateTime.UtcNow, IsActive = true, Salary = 3000000 });

            _context.Employees.Add(new Employee
            { FirstName = "Pedro", LastName = "Ramírez", HireDate = DateTime.UtcNow, IsActive = true, Salary = 2100000 });

            _context.Employees.Add(new Employee
            { FirstName = "Valentina", LastName = "Morales", HireDate = DateTime.UtcNow, IsActive = false, Salary = 1900000 });

            _context.Employees.Add(new Employee
            { FirstName = "Alex", LastName = "Crowley", HireDate = DateTime.UtcNow, IsActive = true, Salary = 3300300 });

            await _context.SaveChangesAsync();
        }
    }
}