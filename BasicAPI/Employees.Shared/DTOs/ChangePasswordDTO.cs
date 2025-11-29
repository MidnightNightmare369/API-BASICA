using System.ComponentModel.DataAnnotations;

namespace Employees.Shared.DTOs;

public class ChangePasswordDTO
{
    [DataType(DataType.Password)]
    [Display(Name = "Current Password")]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "The field {0} must have between {2} and {1} characters.")]
    [Required(ErrorMessage = "The field {0} is required.")]
    public string CurrentPassword { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "New Password")]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "The field {0} must have between {2} and {1} characters.")]
    [Required(ErrorMessage = "The field {0} is required.")]
    public string NewPassword { get; set; } = null!;

    [Compare("NewPassword", ErrorMessage = "The new password and confirmation do not match.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm New Password")]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "The field {0} must have between {2} and {1} characters.")]
    [Required(ErrorMessage = "The field {0} is required.")]
    public string Confirm { get; set; } = null!;
}