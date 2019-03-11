using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewSec.Models;

namespace ViewSec.Data
{
    /// <summary>
    /// medhatelmasry/IdentityCore
    /// Maakt 2 users aan met username admin@GMM.be en user@GMM.be en passwoord Test123.
    /// </summary>
    public class UsersInitializer
    {
        public static async Task Initialize(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId1 = "";
            String userId2 = "";

            string roleAdmin = "Admin";
            string desc1 = "This is the administrator role";

            string roleUser = "User";
            string desc2 = "This is the members role";

            string password = "Test123";

            if (await roleManager.FindByNameAsync(roleAdmin) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(roleAdmin, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(roleUser) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(roleUser, desc2, DateTime.Now));
            }

            if (await userManager.FindByNameAsync("admin@GMM.be") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@GMM.be",
                    Email = "admin@GMM.be",
                    FirstName = "Ad",
                    LastName = "Min"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, roleAdmin);
                }
                adminId1 = user.Id;
            }

            if (await userManager.FindByNameAsync("user@GMM.be") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "user@GMM.be",
                    Email = "user@GMM.be",
                    FirstName = "U",
                    LastName = "Ser"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, roleUser);
                }
                userId2 = user.Id;
            }
        }
    }
}
