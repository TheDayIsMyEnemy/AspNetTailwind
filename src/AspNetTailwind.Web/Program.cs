using System.Globalization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using AspNetTailwind.Infrastructure.Services;
using AspNetTailwind.Web.Filters;

var builder = WebApplication.CreateBuilder(args);

// var connectionStr = builder.Configuration.GetConnectionString("Default");

// builder.Services.AddDbContext<AppDbContext>(
//     dbContextOptions =>
//         dbContextOptions
//             .UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr))
// );

// builder.Services.AddSecurity();
builder.Services.AddScoped<IEmailSender, EmailSender>();
// builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<AuditLogActionFilter>(container =>
{
    var loggerFactory = container.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger<AuditLogActionFilter>();

    return new(logger);
});

builder.Logging.AddFile("logs/{Date}.txt", LogLevel.Information,
    new Dictionary<string, LogLevel>
    {
        { "Microsoft.EntityFrameworkCore", LogLevel.Warning },
        { "Microsoft.AspNetCore", LogLevel.Warning }
    }
);

builder.Services.AddControllersWithViews();

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthentication();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

app.Use(async (context, next) =>
   {
       await next();
       if (context.Response.StatusCode == 404)
       {
           context.Request.Path = "/NotFound";
           await next();
       }
   });

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
// app.UseAuthorization();

app.MapControllerRoute(name: "default",
                       pattern: "{controller=Home}/{action=Index}/{id?}");

// await DbInitializer.Migrate(app.Services);

app.Run();
