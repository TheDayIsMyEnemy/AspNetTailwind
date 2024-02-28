using Microsoft.EntityFrameworkCore;

namespace AspNetTailwind.Infrastructure.Identity
{
    public static class IdentityConfiguration
    {
        private const int PropLength = 50;

        public static void ConfigureIdentity(this ModelBuilder builder)
        {
            builder.Entity<User>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

                b.Property(u => u.Email).HasMaxLength(PropLength);
                b.Property(u => u.NormalizedUserName).HasMaxLength(PropLength);
                b.Property(u => u.UserName).HasMaxLength(PropLength);
                b.Property(u => u.NormalizedUserName).HasMaxLength(PropLength);
                b.Property(u => u.PhoneNumber).HasMaxLength(PropLength);
            });

            builder.Entity<Role>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                b.Property(r => r.Name).HasMaxLength(PropLength);
                b.Property(r => r.NormalizedName).HasMaxLength(PropLength);
            });
        }
    }
}
