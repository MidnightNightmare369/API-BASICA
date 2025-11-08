using System.ComponentModel;

namespace Employees.Shared.Enums;

public enum UserType
{
    [Description("Admin User")]
    Admin,

    [Description("Default User")]
    User
}