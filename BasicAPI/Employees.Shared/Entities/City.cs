using Employees.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Employees.Shared.Entities;

public class City : IEntityWithName
{
    public int Id { get; set; }

    [Display(Name = "Ciudad")]
    [MaxLength(100, ErrorMessage = "The {0} parameter must have a maximum of {1} characters.")]
    [Required(ErrorMessage = "The {0} field is required.")]
    public string Name { get; set; } = null!;

    public int StateId { get; set; }
    public State? State { get; set; }

    public ICollection<User>? Users { get; set; }
}