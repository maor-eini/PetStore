using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Models;

namespace PetStore.EntityConfigurations
{
    public static class UserConfiguration
    {
        public static void ConfigureUser(this EntityTypeBuilder<UserAccount> b)
        {
            b.ToTable("Accounts","User")
                .Property(p => p.Id)
                .HasColumnName("UserId");

            b.Property(ua => ua.FirstName)
                .HasMaxLength(255);

            b.Property(ua => ua.LastName)
                .HasMaxLength(255);

            b.Property(ua => ua.Gender)
                 .HasMaxLength(1);

            b.Property(ua => ua.IsActive)
                .HasMaxLength(1);

            b.HasOne(ua => ua.UserAddress)
                .WithOne(uadd => uadd.UserAccount)
                .HasForeignKey<UserAddress>(uadd => uadd.UserAccountId)
                .HasPrincipalKey<UserAccount>(ua=>ua.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            b.HasOne(ua => ua.ShoppingCart)
                .WithOne(sc => sc.UserAccount)
                .HasForeignKey<ShoppingCart>(sc => sc.UserAccountId)
                .HasPrincipalKey<UserAccount>(ua => ua.Id)
                .OnDelete(DeleteBehavior.Cascade);

            b.HasOne(ua => ua.Pet)
                .WithOne(p => p.UserAccount)
                .HasForeignKey<Pet>(p => p.UserAccountId)
                .HasPrincipalKey<UserAccount>(ua => ua.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public static void ConfigureUserAddress(this EntityTypeBuilder<UserAddress> b)
        {
            b.ToTable("Addresses", "User");

            b.HasKey(ua => ua.Id);
                
        }

        public static void ConfigureIdentityUser(this EntityTypeBuilder<IdentityUser> b)
        {           
            b.ToTable("Accounts", "User")
                .Property(p => p.Id)
                .HasColumnName("UserId");
        }

        public static void ConfigureUserRole(this EntityTypeBuilder<UserRole> b)
        {
            b.ToTable("Roles","User"); 
        }

        public static void ConfigureIdentityUserRole(this EntityTypeBuilder<IdentityUserRole<int>> b)
        {
            b.ToTable("UserRoles", "User");
        }

        public static void ConfigureIdentityUserLogin(this EntityTypeBuilder<IdentityUserLogin<int>> b)
        {
            b.ToTable("UserLogins", "User");
        }

        public static void ConfigureIdentityUserToken(this EntityTypeBuilder<IdentityUserToken<int>> b)
        {
            b.ToTable("UserTokens", "User");
        }

        public static void ConfigureIdentityUserClaim(this EntityTypeBuilder<IdentityUserClaim<int>> b)
        {
            b.ToTable("UserClaims", "User");
        }

        public static void ConfigureIdentityRoleClaim(this EntityTypeBuilder<IdentityRoleClaim<int>> b)
        {
            b.ToTable("RoleClaims", "User");
        }
    }
}
