using Microsoft.AspNetCore.Identity;
using VTU_Manager.Domain.Entities;

namespace VTU_Manager.Web.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<VTUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<VTUser> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
