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

            b.HasOne(ua => ua.Image)
                .WithOne(ui => ui.UserAccount)
                .HasForeignKey<UserImage>(ui => ui.UserAccountId)
                .HasPrincipalKey<UserAccount>(ua => ua.Id)
                .OnDelete(DeleteBehavior.Cascade);

            b.HasMany(ua => ua.UserAddresses)
                .WithOne(uadd => uadd.UserAccount)
                .HasForeignKey(uadd => uadd.UserAccountId)
                .HasPrincipalKey(ua=>ua.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            b.HasOne(ua => ua.ShoppingCart)
                .WithOne(sc => sc.UserAccount)
                .HasForeignKey<ShoppingCart>(sc => sc.UserAccountId)
                .HasPrincipalKey<UserAccount>(ua => ua.Id)
                .OnDelete(DeleteBehavior.Cascade);

            b.HasMany(ua => ua.Pets)
                .WithOne(p => p.UserAccount)
                .HasForeignKey(p => p.UserAccountId)
                .HasPrincipalKey(ua => ua.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public static void ConfigureUserAddress(this EntityTypeBuilder<UserAddress> b)
        {
            b.ToTable("Addresses", "User");

            b.HasKey(ua => ua.Id);
                
        }

        public static void ConfigureUserImage(this EntityTypeBuilder<UserImage> b)
        {
            b.ToTable("Images", "User");

            b.HasKey(ua => ua.Id);

        }

        public static void ConfigureIdentityUser(this EntityTypeBuilder<IdentityUser> b)
        {           
            b.ToTable("Accounts", "User")
                .Property(p => p.Id)
                .HasColumnName("UserId");
        }

        public static void ConfigureIdentityRole(this EntityTypeBuilder<IdentityRole> b)
        {
            b.ToTable("Roles","User");
        }

        public static void ConfigureIdentityUserRole(this EntityTypeBuilder<IdentityUserRole<string>> b)
        {
            b.ToTable("UserRoles", "User");
        }

        public static void ConfigureIdentityUserLogin(this EntityTypeBuilder<IdentityUserLogin<string>> b)
        {
            b.ToTable("UserLogins", "User");
        }

        public static void ConfigureIdentityUserToken(this EntityTypeBuilder<IdentityUserToken<string>> b)
        {
            b.ToTable("UserTokens", "User");
        }

        public static void ConfigureIdentityUserClaim(this EntityTypeBuilder<IdentityUserClaim<string>> b)
        {
            b.ToTable("UserClaims", "User");
        }

        public static void ConfigureIdentityRoleClaim(this EntityTypeBuilder<IdentityRoleClaim<string>> b)
        {
            b.ToTable("RoleClaims", "User");
        }
    }
}
