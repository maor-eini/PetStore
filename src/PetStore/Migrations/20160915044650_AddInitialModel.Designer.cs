using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PetStore.Data;

namespace PetStore.Migrations
{
    [DbContext(typeof(PetStoreContext))]
    [Migration("20160915044650_AddInitialModel")]
    partial class AddInitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("ApplicationData")
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims","User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims","User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins","User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles","User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens","User");
                });

            modelBuilder.Entity("PetStore.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("OrderedDate");

                    b.Property<DateTime>("ShippedDate");

                    b.Property<int>("ShippingAddressId");

                    b.Property<int>("StatusId");

                    b.Property<double>("TotalPrice");

                    b.Property<int>("UserAccountId");

                    b.HasKey("Id");

                    b.HasIndex("ShippingAddressId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserAccountId");

                    b.ToTable("Orders","Order");
                });

            modelBuilder.Entity("PetStore.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems","Order");
                });

            modelBuilder.Entity("PetStore.Models.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus","Order");
                });

            modelBuilder.Entity("PetStore.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Size");

                    b.Property<int>("TypeId");

                    b.Property<int>("UserAccountId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId")
                        .IsUnique();

                    b.HasIndex("UserAccountId")
                        .IsUnique();

                    b.ToTable("Pets","Pet");
                });

            modelBuilder.Entity("PetStore.Models.PetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PetTypes","Pets");
                });

            modelBuilder.Entity("PetStore.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<string>("ProductCode");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products","Product");
                });

            modelBuilder.Entity("PetStore.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Category","Product");
                });

            modelBuilder.Entity("PetStore.Models.ProductImage", b =>
                {
                    b.Property<int>("Id");

                    b.Property<byte[]>("Image");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Images","Product");
                });

            modelBuilder.Entity("PetStore.Models.ProductSubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MainCategoryId");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("MainCategoryId");

                    b.ToTable("SubCategories","Product");
                });

            modelBuilder.Entity("PetStore.Models.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ProviderName");

                    b.HasKey("Id");

                    b.ToTable("Providers","Provider");
                });

            modelBuilder.Entity("PetStore.Models.ProviderItem", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("ProviderId");

                    b.Property<int>("Quantity");

                    b.HasKey("ProductId", "ProviderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProviderId");

                    b.ToTable("ProviderItems","Provider");
                });

            modelBuilder.Entity("PetStore.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("UserAccountId");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId")
                        .IsUnique();

                    b.ToTable("ShoppingCarts","User");
                });

            modelBuilder.Entity("PetStore.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("ShoppingCartId", "ProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartItems","User");
                });

            modelBuilder.Entity("PetStore.Models.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.Property<int>("UserAddressId");

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApartmentNumber");

                    b.Property<string>("BuildingNumber");

                    b.Property<string>("City");

                    b.Property<string>("Province");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<int>("UserAccountId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId")
                        .IsUnique();

                    b.ToTable("Addresses","User");
                });

            modelBuilder.Entity("PetStore.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("PetStore.Models.UserRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("PetStore.Models.UserAccount")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("PetStore.Models.UserAccount")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<int>", b =>
                {
                    b.HasOne("PetStore.Models.UserRole")
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

                    b.HasOne("PetStore.Models.OrderStatus", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId");

                    b.HasOne("PetStore.Models.UserAccount")
                        .WithMany("Orders")
                        .HasForeignKey("UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                        .WithOne("Pet")
                        .HasForeignKey("PetStore.Models.Pet", "TypeId");

                    b.HasOne("PetStore.Models.UserAccount", "UserAccount")
                        .WithOne("Pet")
                        .HasForeignKey("PetStore.Models.Pet", "UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetStore.Models.Product", b =>
                {
                    b.HasOne("PetStore.Models.ProductCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("PetStore.Models.ProductImage", b =>
                {
                    b.HasOne("PetStore.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetStore.Models.ProductSubCategory", b =>
                {
                    b.HasOne("PetStore.Models.ProductCategory", "MainCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("MainCategoryId")
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
                        .WithOne("UserAddress")
                        .HasForeignKey("PetStore.Models.UserAddress", "UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
