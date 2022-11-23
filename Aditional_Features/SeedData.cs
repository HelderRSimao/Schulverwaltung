﻿using Microsoft.AspNetCore.Identity;


namespace Schulverwaltung.Data
{
    public static class SeedData
    {
        public static void Seed(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedUsers(userManager);
            SeedRoles(roleManager);
           
        }
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@localhost.com"



                };
                var result = userManager.CreateAsync(user, "P@ssword69").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
            if (userManager.FindByNameAsync("employer").Result == null)
            {
                var user = new  ApplicationUser
                {
                    UserName = "employer",
                    Email = "employer@localhost.com"



                };
                var result = userManager.CreateAsync(user, "P@ssword90").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Employee").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {

                    Name = "Administrator"
                };
                var result = roleManager.CreateAsync(role);
            }
            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var role = new IdentityRole
                {

                    Name = "Employee"
                };
                var result = roleManager.CreateAsync(role);
            }
        }
    }
}
