using Microsoft.AspNetCore.Identity;

namespace AspNetTailwind.Infrastructure.Identity
{
    public class User : IdentityUser
    {
        public bool IsBlocked { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; } = null!;
    }
}
