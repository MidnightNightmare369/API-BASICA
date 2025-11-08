using Employees.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Employees.Shared.Entities;

public class User : IdentityUser
{
    [Display(Name = "ID (Cedula)")]
    [MaxLength(20, ErrorMessage = "The {0} parameter must have a maximum of {1} digits.")]
    [Required(ErrorMessage = "The {0} field is required")]
    public string Document { get; set; } = null!;

    [Display(Name = "First Name")]
    [MaxLength(50, ErrorMessage = "The {0} parameter must have a maximum of {1} characters.")]
    [Required(ErrorMessage = "The {0} field is required.")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last name")]
    [MaxLength(50, ErrorMessage = "The {0} parameter must have a maximum of {1} characters.")]
    [Required(ErrorMessage = "The {0} field is required.")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Address")]
    [MaxLength(200, ErrorMessage = "The {0} parameter must have a maximum of {1} characters.")]
    [Required(ErrorMessage = "The {0} field is required.")]
    public string Address { get; set; } = null!;

    [Display(Name = "Profile picture")]
    public string? Photo { get; set; }

    [Display(Name = "Type of user")]
    public UserType UserType { get; set; }

    public City? City { get; set; }

    [Display(Name = "City")]
    [Range(1, int.MaxValue, ErrorMessage = "You must select one {0}.")]
    public int CityId { get; set; }

    [Display(Name = "User")]
    public string FullName => $"{FirstName} {LastName}";
}