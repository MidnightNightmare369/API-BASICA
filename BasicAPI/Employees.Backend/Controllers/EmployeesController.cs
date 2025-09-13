using Employees.Backend.UnitsOfWork.Interfaces;
using Employees.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : GenericController<Employee>
{
    private readonly IEmployeesUnitOfWork _employeeUnitOfWork;

    public EmployeesController(IGenericUnitOfWork<Employee> unitOfWork, IEmployeesUnitOfWork employeeUnitOfWork) : base(unitOfWork)
    {
        _employeeUnitOfWork = employeeUnitOfWork;
    }

    [HttpGet("condition")]
    public async Task<IActionResult> GetByNameAsync(string condition)
    {
        var response = await _employeeUnitOfWork.GetByNameAsync(
            e => e.FirstName.ToLower().Contains(condition) || e.LastName.ToLower().Contains(condition)
            );

        if (!response.WasSuccess)
        {
            return BadRequest(response.Message);
        }

        return Ok(response.Result);
    }
}