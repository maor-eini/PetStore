using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PetStore.Models
{
    public class PetStoreContext : IdentityDbContext
    {
        public PetStoreContext(DbContextOptions<PetStoreContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
   
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>()
                .ToTable("Users")
                .Property(p => p.Id)
                .HasColumnName("UserId");

            builder.Entity<User>()
                .ToTable("Users")
                .Property(p => p.Id)
                .HasColumnName("UserId");

            builder.Entity<IdentityRole>()
                .ToTable("Users.Roles");

            builder.Entity<IdentityUserRole<string>>()
                .ToTable("Users.UserRoles");

            builder.Entity<IdentityUserLogin<string>>()
                .ToTable("Users.UserLogins");

            builder.Entity<IdentityUserToken<string>>()
                .ToTable("Users.UserTokens");

            builder.Entity<IdentityUserClaim<string>>()
                .ToTable("Users.UserClaims");

            builder.Entity<IdentityRoleClaim<string>>()
                .ToTable("Users.RoleClaims");
        }
    }
}
