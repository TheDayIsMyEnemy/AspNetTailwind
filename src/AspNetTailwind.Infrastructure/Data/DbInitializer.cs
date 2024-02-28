using AspNetTailwind.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetTailwind.Infrastructure.Data
{
    public class DbInitializer
    {
        public static async Task Migrate(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<AppDbContext>();
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<Role>>();
            var logger = services.GetRequiredService<ILogger<DbInitializer>>();

            try
            {
                await context.Database.MigrateAsync();

                if (!roleManager.Roles.Any())
                {
                    await roleManager.CreateAsync(new Role(Constants.Admin));
                    await context.SaveChangesAsync();
                }

                if (!userManager.Users.Any())
                {
                    await CreateAdminUser("support@asptailwind.net", userManager);

                    await context.SaveChangesAsync();

                    logger.LogInformation("Admin users created!");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, "");
                throw;
            }
        }

        private static async Task<User> CreateAdminUser(string email, UserManager<User> userManager)
        {
            var admin = new User { UserName = email, Email = email };

            var result = await userManager.CreateAsync(admin, "SupportAspNetTailwind111!");

            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            if (!await userManager.IsInRoleAsync(admin, Constants.Admin))
                await userManager.AddToRoleAsync(admin, Constants.Admin);

            return admin;
        }
    }
}
