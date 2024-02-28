using AspNetTailwind.Infrastructure.Data;
using AspNetTailwind.Infrastructure.Identity;
using AspNetTailwind.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetTailwind.Web.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddSecurity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(options =>
            {
                options.Stores.MaxLengthForKeys = 128;
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
                //options.User.AllowedUserNameCharacters = null;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddUserConfirmation<UserConfirmation>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true;
                options.LoginPath = new PathString(Constants.LoginPath);
                options.LogoutPath = new PathString(Constants.LogoutPath);
            });
        }

        // public static void AddApplicationServices(this IServiceCollection services)
        // {

        // }

        // public static void ConfigureOptions(
        //     this IServiceCollection services,
        //     ConfigurationManager config)
        // {

        // }
    }
}
