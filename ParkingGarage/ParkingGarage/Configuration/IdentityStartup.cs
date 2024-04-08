using Microsoft.AspNetCore.Identity;
using ParkingGarage.Domain.Entities;
using ParkingGarage.Domain.Entities.Enums;
using Serilog;

namespace ParkingGarage.Configuration
{
    public static class IdentityStartup
    {
        public static IApplicationBuilder UseApplicationIdentity(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

                SeedRoles(roleManager).Wait();
                SeedUsers(userManager).Wait();
                SeedUserRoles(userManager).Wait();
            }

            return builder;
        }
        private static IEnumerable<Role> Roles()
        {
            return new List<Role>
        {
            new Role {Id = "role_admin", Name = RolesConstants.ADMIN},
            new Role {Id = "role_security",Name = RolesConstants.SECURITY}
        };
        }

        private static IEnumerable<User> Users()
        {
            return new List<User>
        {

            new User
            {
                Id = "user-2",
                UserName = "admin",
                PasswordHash = "$2a$10$gSAhZrxMllrbgj/kkK9UceBPpChGWJA7SYIb1Mqo.n5aNLq1/oRrC",
                FirstName = "admin",
                LastName = "Administrator",
                Email = "admin@localhost",
                ImageUrl = ""
            },
            new User
            {
                Id = "f38d0c0e-78fa-4b05-a112-6aa676dd8a57",
                UserName = "security",
                PasswordHash = "$2a$11$SuIC5tlfoAOSqcSbvNwoy.K.LRt/Iqm.GsjEXbCXMxyC.XfuCY.N.",
                FirstName = "security",
                LastName = "Security",
                Email = "security@localhost",
                ImageUrl = ""
            }
        };
        }

        private static IDictionary<string, string[]> UserRoles()
        {
            return new Dictionary<string, string[]>
        {
            { "user-2", new[] {RolesConstants.ADMIN}},
                { "f38d0c0e-78fa-4b05-a112-6aa676dd8a57", new[] {RolesConstants.SECURITY}}
        };
        }


        private static async Task SeedRoles(RoleManager<Role> roleManager)
        {
            foreach (var role in Roles())
            {
                var dbRole = await roleManager.FindByNameAsync(role.Name);
                if (dbRole == null)
                {
                    try
                    {
                        await roleManager.CreateAsync(role);
                    }
                    catch (Exception e)
                    {
                        Log.Warning(e, "Error in seed roles");

                        await roleManager.CreateAsync(role);
                    }
                }
                else
                {
                    await roleManager.UpdateAsync(dbRole);
                }
            }
        }

        private static async Task SeedUsers(UserManager<User> userManager)
        {
            foreach (var user in Users())
            {
                var dbUser = await userManager.FindByIdAsync(user.Id);
                if (dbUser == null)
                {
                    try
                    {
                        await userManager.CreateAsync(user);
                    }
                    catch (Exception e)
                    {
                        Log.Warning(e, "Error in seed users");
                    }
                }
                else
                {
                    await userManager.UpdateAsync(dbUser);
                }
            }
        }

        private static async Task SeedUserRoles(UserManager<User> userManager)
        {
            foreach (var (id, roles) in UserRoles())
            {
                try
                {
                    var user = await userManager.FindByIdAsync(id);
                    await userManager.AddToRolesAsync(user, roles);
                }
                catch (Exception e)
                {
                    Log.Warning(e, "Error in seed user roles");

                    var user = await userManager.FindByIdAsync(id);
                    await userManager.AddToRolesAsync(user, roles);
                }
            }
        }
    }
}
