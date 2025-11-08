using Employees.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Employees.Shared.Entities;

public class State : IEntityWithName
{
    public int Id { get; set; }

    [Display(Name = "Estado")]
    [MaxLength(100, ErrorMessage = "The {0} parameter must have a maximum of {1} characters.")]
    [Required(ErrorMessage = "The {0} field is required.")]
    public string Name { get; set; } = null!;

    //Relacion con Country
    public int CountryId { get; set; }

    public Country? Country { get; set; }

    //Relacion con City
    public ICollection<City>? Cities { get; set; }

    public int CitiesNumber => Cities == null ? 0 : Cities.Count();
}