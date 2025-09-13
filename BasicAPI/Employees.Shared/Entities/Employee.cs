using System.ComponentModel.DataAnnotations;

namespace Employees.Shared.Entities;

public class Employee
{
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    [MaxLength(30, ErrorMessage = "El parametro {0} debe tener un maximo de {1} caracteres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Apellido")]
    [MaxLength(30, ErrorMessage = "El parametro {0} debe tener un maximo de {1} caracteres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string LastName { get; set; } = null!;

    public Boolean IsActive { get; set; }
    public DateTime HireDate { get; set; }

    [Display(Name = "Salario")]
    [Range(1000000, double.MaxValue, ErrorMessage = "El salario debe ser minimo de 1000000 ")]
    public decimal Salary { get; set; }
}