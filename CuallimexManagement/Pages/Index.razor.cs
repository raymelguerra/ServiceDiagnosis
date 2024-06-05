using CuallimexManagement.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;


namespace CuallimexManagement.Pages;

public partial class Index
{
    private List<string> userRoles = [];

    [Inject]
    private ISnackbar Snackbar { get; set; }

    [Inject]
    private ISecurityManagement Security { get; set; }

    protected override async Task OnInitializedAsync()
    {
        IEnumerable<string>? roles = null;
        try
        {
            var user = await UserManagement.GetUserContextMainData();
            if (!string.IsNullOrEmpty(user.Username))
            {
                var userId = UserManagement.GetUserId();
                roles = UserManagement.GetUserRoles();
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Oops, an error occurred getting user roles. The error type is: {ex.Message}.", Severity.Error);
        }

        userRoles = roles is null ? [] : roles.ToList();
    }
}
