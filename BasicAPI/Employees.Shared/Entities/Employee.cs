using Orders.Share.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Employees.Shared.Entities;

public class Employee : IEntityWithName
{
    public int Id { get; set; }

    [Display(Name = "Name")]
    [MaxLength(30, ErrorMessage = "The {0} parameter must have a maximum of {1} characters.")]
    [Required(ErrorMessage = "The {0} field is required.")]
    public string Name { get; set; } = null!;

    [Display(Name = "Last Name")]
    [MaxLength(30, ErrorMessage = "The {0} parameter must have a maximum of {1} characters.")]
    [Required(ErrorMessage = "The {0} field is required.")]
    public string LastName { get; set; } = null!;

    public Boolean IsActive { get; set; }

    public DateTime HireDate { get; set; }

    [Display(Name = "Salary")]
    [Range(1000000, double.MaxValue, ErrorMessage = "The salary must be at least 1,000,000")]
    public decimal Salary { get; set; }
}