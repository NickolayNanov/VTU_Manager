using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using MudBlazor;
using VTU_Manager.Domain.Entities;

namespace VTU_Manager.Web.Components.Layout
{
    public partial class MainLayoutBase : LayoutComponentBase
    {
        [Inject] protected NavigationManager Navigation { get; set; }

        [Inject] protected SignInManager<VTUser> SignInManager { get; set; }

        protected bool _drawerOpen = true;

        protected string SideBarDisplayIcon = Icons.Material.Filled.KeyboardDoubleArrowLeft;

        protected void OnNavbarIconClick()
        {
            if (SideBarDisplayIcon == Icons.Material.Filled.KeyboardDoubleArrowLeft)
            {
                SideBarDisplayIcon = Icons.Material.Filled.KeyboardDoubleArrowRight;
            }
            else
            {
                SideBarDisplayIcon = Icons.Material.Filled.KeyboardDoubleArrowLeft;
            }

            DrawerToggle();
        }

        protected void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        protected void RedirectTo(string url)
        {
            Navigation.NavigateTo(url);
        }

        protected async Task Logout()
        {
            await SignInManager.SignOutAsync();
            StateHasChanged();
        }
    }
}
