using Employees.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Employees.Shared.Entities;

public class Country : IEntityWithName
{
    public int Id { get; set; }

    [Display(Name = "Country name")]
    [MaxLength(100, ErrorMessage = "The {0} parameter must have a maximum of {1} characters.")]
    [Required(ErrorMessage = "The {0} field is required.")]
    public string Name { get; set; } = null!;

    //Relacion con States
    public ICollection<State>? States { get; set; }

    public int StatesNumber => States == null ? 0 : States.Count();
}