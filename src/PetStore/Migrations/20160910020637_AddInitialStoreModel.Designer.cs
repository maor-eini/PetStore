using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PetStore.Models;

namespace PetStore.Migrations
{
    [DbContext(typeof(PetStoreContext))]
    [Migration("20160910020637_AddInitialStoreModel")]
    partial class AddInitialStoreModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("ApplicationData")
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("Roles","User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims","User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims","User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins","User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles","User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens","User");
                });

            modelBuilder.Entity("PetStore.Models.Order", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("OrderedDate");

                    b.Property<DateTime>("ShippedDate");

                    b.Property<string>("ShippingAddressId");

                    b.Property<int>("Status");

                    b.Property<double>("TotalPrice");

                    b.Property<string>("UserAccountId");

                    b.HasKey("Id");

                    b.HasIndex("ShippingAddressId");

                    b.HasIndex("UserAccountId");

                    b.ToTable("Orders","Order");
                });

            modelBuilder.Entity("PetStore.Models.OrderItem", b =>
                {
                    b.Property<string>("OrderId");

                    b.Property<string>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems","Order");
                });

            modelBuilder.Entity("PetStore.Models.Pet", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Name");

                    b.Property<string>("Size");

                    b.Property<string>("TypeId");

                    b.Property<string>("UserAccountId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserAccountId");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("PetStore.Models.PetType", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PetType");
                });

            modelBuilder.Entity("PetStore.Models.Product", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("CategoryId")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.Property<string>("ProductCode");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId")
                        .IsUnique();

                    b.ToTable("Products","Product");
                });

            modelBuilder.Entity("PetStore.Models.ProductCategory", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Name");

                    b.Property<int?>("SubCategoryId");

                    b.Property<string>("SubCategoryId1");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId1");

                    b.ToTable("Category","Product");
                });

            modelBuilder.Entity("PetStore.Models.ProductImage", b =>
                {
                    b.Property<string>("Id");

                    b.Property<byte[]>("Image");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Images","Product");
                });

            modelBuilder.Entity("PetStore.Models.ProductTag", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ProductId")
                        .IsRequired();

                    b.Property<string>("Tag");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Tags","Product");
                });

            modelBuilder.Entity("PetStore.Models.Provider", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Description");

                    b.Property<string>("ProviderName");

                    b.HasKey("Id");

                    b.ToTable("Providers","Provider");
                });

            modelBuilder.Entity("PetStore.Models.ProviderItem", b =>
                {
                    b.Property<string>("ProductId");

                    b.Property<string>("ProviderId");

                    b.Property<int>("Quantity");

                    b.HasKey("ProductId", "ProviderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProviderId");

                    b.ToTable("ProviderItems","Provider");
                });

            modelBuilder.Entity("PetStore.Models.ShoppingCart", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("UserAccountId");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId")
                        .IsUnique();

                    b.ToTable("ShoppingCarts","User");
                });

            modelBuilder.Entity("PetStore.Models.ShoppingCartItem", b =>
                {
                    b.Property<string>("ShoppingCartId");

                    b.Property<string>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("ShoppingCartId", "ProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartItems","User");
                });

            modelBuilder.Entity("PetStore.Models.UserAccount", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("UserId");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Gender")
                        .HasAnnotation("MaxLength", 1);

                    b.Property<string>("ImageId");

                    b.Property<string>("IsActive")
                        .HasAnnotation("MaxLength", 1);

                    b.Property<string>("LastName")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<DateTime>("LastUpdated");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PasswordOld");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserAddressesId");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("Accounts","User");
                });

            modelBuilder.Entity("PetStore.Models.UserAddress", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ApartmentNumber");

                    b.Property<string>("BuildingNumber");

                    b.Property<string>("City");

                    b.Property<string>("IsDefaultBillingAddress");

                    b.Property<string>("IsDefaultShippingAddress");

                    b.Property<string>("Province");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<string>("UserAccountId")
                        .IsRequired();

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId");

                    b.ToTable("Addresses","User");
                });

            modelBuilder.Entity("PetStore.Models.UserImage", b =>
                {
                    b.Property<string>("Id");

                    b.Property<byte[]>("Image");

                    b.Property<string>("UserAccountId");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId")
                        .IsUnique();

                    b.ToTable("Images","User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PetStore.Models.UserAccount")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PetStore.Models.UserAccount")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PetStore.Models.UserAccount")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetStore.Models.Order", b =>
                {
                    b.HasOne("PetStore.Models.UserAddress", "ShippingAddress")
                        .WithMany("Orders")
                        .HasForeignKey("ShippingAddressId");

                    b.HasOne("PetStore.Models.UserAccount")
                        .WithMany("Orders")
                        .HasForeignKey("UserAccountId");
                });

            modelBuilder.Entity("PetStore.Models.OrderItem", b =>
                {
                    b.HasOne("PetStore.Models.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PetStore.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetStore.Models.Pet", b =>
                {
                    b.HasOne("PetStore.Models.PetType", "Type")
                        .WithMany("Pets")
                        .HasForeignKey("TypeId");

                    b.HasOne("PetStore.Models.UserAccount", "UserAccount")
                        .WithMany("Pets")
                        .HasForeignKey("UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetStore.Models.Product", b =>
                {
                    b.HasOne("PetStore.Models.ProductCategory", "Category")
                        .WithOne()
                        .HasForeignKey("PetStore.Models.Product", "CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetStore.Models.ProductCategory", b =>
                {
                    b.HasOne("PetStore.Models.ProductCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId1");
                });

            modelBuilder.Entity("PetStore.Models.ProductImage", b =>
                {
                    b.HasOne("PetStore.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetStore.Models.ProductTag", b =>
                {
                    b.HasOne("PetStore.Models.Product", "Product")
                        .WithMany("Tags")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetStore.Models.ProviderItem", b =>
                {
                    b.HasOne("PetStore.Models.Product", "Product")
                        .WithMany("Providers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PetStore.Models.Provider", "Provider")
                        .WithMany("Products")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetStore.Models.ShoppingCart", b =>
                {
                    b.HasOne("PetStore.Models.UserAccount", "UserAccount")
                        .WithOne("ShoppingCart")
                        .HasForeignKey("PetStore.Models.ShoppingCart", "UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetStore.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("PetStore.Models.Product", "Product")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PetStore.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetStore.Models.UserAddress", b =>
                {
                    b.HasOne("PetStore.Models.UserAccount", "UserAccount")
                        .WithMany("UserAddresses")
                        .HasForeignKey("UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetStore.Models.UserImage", b =>
                {
                    b.HasOne("PetStore.Models.UserAccount", "UserAccount")
                        .WithOne("Image")
                        .HasForeignKey("PetStore.Models.UserImage", "UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
