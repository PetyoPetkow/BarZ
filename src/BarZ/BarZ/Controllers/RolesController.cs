namespace TaskScript.Application.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using BarZ.Constants;

    [Authorize(Roles = RolesConstants.AdminRoleName)]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Create()
        {
            IdentityRole userRole = new IdentityRole
            {
                Name = RolesConstants.UserRoleName,
            };
            IdentityRole adminRole = new IdentityRole
            {
                Name = RolesConstants.AdminRoleName,
            };

            await this.roleManager.CreateAsync(userRole);
            await this.roleManager.CreateAsync(adminRole);

            return this.Redirect("/");
        }
    }
}