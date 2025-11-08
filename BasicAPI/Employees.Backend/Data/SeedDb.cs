using Employees.Backend.UnitsOfWork.Implementations;
using Employees.Backend.UnitsOfWork.Interfaces;
using Employees.Shared.Entities;
using Employees.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace Employees.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;
    private readonly IUsersUnitOfWork _usersUnitOfWork;

    public SeedDb(DataContext context, IUsersUnitOfWork usersUnitOfWork)
    {
        _context = context;
        _usersUnitOfWork = usersUnitOfWork;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckFullEmployeesAsync();
        await CheckCountriesFullAsync();
        await CheckRolesAsync();
        await CheckUserAsync("369", "Root", "Root", "root@yopmail.com", "333 666 999", "03 06 09", UserType.Admin);
    }
    
    private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
    {
        var user = await _usersUnitOfWork.GetUserAsync(email);
        if (user == null)
        {
            user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
                PhoneNumber = phone,
                Address = address,
                Document = document,
                City = _context.Cities.FirstOrDefault(),
                UserType = userType,
            };

            await _usersUnitOfWork.AddUserAsync(user, "123456");
            await _usersUnitOfWork.AddUserToRoleAsync(user, userType.ToString());
        }

        return user;
    }

    private async Task CheckRolesAsync()
    {
        await _usersUnitOfWork.CheckRoleAsync(UserType.Admin.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.User.ToString());
    }
    
    private async Task CheckCountriesFullAsync()
    {
        if (!_context.Countries.Any())
        {
            _context.Database.SetCommandTimeout(300); // Añadi esta linea ya que mi pc tarda mucho en cargar y arroja error timeout
            var countriesSQLScript = File.ReadAllText("Data\\CountriesStatesCities.sql");
            await _context.Database.ExecuteSqlRawAsync(countriesSQLScript);
        }
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