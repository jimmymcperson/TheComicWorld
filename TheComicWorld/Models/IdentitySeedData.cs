using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TheComicWorld.Models
{
    public static class IdentitySeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            AppIdentityDbContext context = app.ApplicationServices.GetRequiredService<AppIdentityDbContext>();
            context.Database.Migrate();
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<AppUser> userManager)
        {
            if (userManager.FindByNameAsync("Customer").Result == null)
            {
                AppUser user = new AppUser();
                user.UserName = "Customer";

                IdentityResult result = userManager.CreateAsync
                    (user, "Customer123$").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Customer").Wait();
                }
            }

            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                AppUser user = new AppUser();
                user.UserName = "Admin";

                IdentityResult result = userManager.CreateAsync
                    (user, "Admin123$").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Customer").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Customer";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
