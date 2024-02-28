using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetTailwind.ApplicationCore.Models;
using AspNetTailwind.Infrastructure.Identity;

namespace AspNetTailwind.Infrastructure.Data
{
    public class AppDbContext
        : IdentityDbContext<
            User,
            Role,
            string,
            IdentityUserClaim<string>,
            UserRole,
            IdentityUserLogin<string>,
            IdentityRoleClaim<string>,
            IdentityUserToken<string>
        >
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var columnLength = 50;

            builder.Entity<Product>().HasIndex(p => p.Code).IsUnique(true);
            builder.Entity<Product>().Property(p => p.Code).HasMaxLength(columnLength);

            builder.Entity<Category>().HasIndex(f => f.Name).IsUnique(true);
            builder.Entity<Category>().Property(p => p.Name).HasMaxLength(columnLength);

            builder.ConfigureIdentity();
        }
    }
}
