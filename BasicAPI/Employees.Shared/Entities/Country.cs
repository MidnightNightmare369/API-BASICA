using Employees.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Employees.Shared.Entities;

public class Country : IEntityWithName
{
    public int Id { get; set; }

    [Display(Name = "Pais")]
    [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Name { get; set; } = null!;

    //Relacion con States
    public ICollection<State>? States { get; set; }

    public int StatesNumber => States == null ? 0 : States.Count();
}