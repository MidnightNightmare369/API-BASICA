using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Employees.Frontend.AuthenticationProvider;

public class AuthenticationProviderTest : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var anonimous = new ClaimsIdentity();
        var user = new ClaimsIdentity(authenticationType: "test");
        var admin = new ClaimsIdentity(
        [
            new("FirstName", "Root"),
            new("LastName", "Admin"),
            new(ClaimTypes.Name, "root@yopmail.com"),
            new(ClaimTypes.Role, "Admin")
        ],
        authenticationType: "test");

        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(admin)));
    }
}