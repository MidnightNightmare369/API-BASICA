using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Employees.Frontend.Components.Pages.Auth;
using MudBlazor;

namespace Employees.Frontend.Components.Shared;

public partial class AuthLinks
{
    private string? photoUser;

    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private IDialogService DialogService { get; set; } = null!;
    [CascadingParameter] private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

    protected override async Task OnParametersSetAsync()
    {
        var authenticationState = await AuthenticationStateTask;
        var claims = authenticationState.User.Claims.ToList();
        var photoClaim = claims.FirstOrDefault(x => x.Type == "Photo");
        var nameClaim = claims.FirstOrDefault(x => x.Type == "UserName");
        if (photoClaim is not null)
        {
            photoUser = photoClaim.Value;
        }
    }

    private void EditAction()
    {
        NavigationManager.NavigateTo("/EditUser");
    }

    private void ShowModalLogIn()
    {
        var closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };
        DialogService.ShowAsync<Login>("Login", closeOnEscapeKey);
    }

    private void ShowModalLogOut()
    {
        var closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };
        DialogService.ShowAsync<Logout>("Logout", closeOnEscapeKey);
    }

    private void ShowModalRegister()
    {
        var closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };
        DialogService.ShowAsync<Register>("Register User", closeOnEscapeKey);
    }
}