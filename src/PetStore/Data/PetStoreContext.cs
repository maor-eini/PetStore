using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetStore.EntityConfigurations;
using PetStore.Models;

namespace PetStore.Data
{
    public class PetStoreContext : IdentityDbContext<UserAccount, UserRole , int>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderItem> ProviderItems { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }

        public PetStoreContext(DbContextOptions<PetStoreContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
   
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("ApplicationData");

            builder.Entity<UserRole>().ConfigureUserRole();

            builder.Entity<IdentityUserRole<int>>().ConfigureIdentityUserRole();

            builder.Entity<IdentityUserLogin<int>>().ConfigureIdentityUserLogin();

            builder.Entity<IdentityUserToken<int>>().ConfigureIdentityUserToken();

            builder.Entity<IdentityUserClaim<int>>().ConfigureIdentityUserClaim();

            builder.Entity<IdentityRoleClaim<int>>().ConfigureIdentityRoleClaim();


            builder.Entity<UserAccount>().ConfigureUser();

            builder.Entity<UserAddress>().ConfigureUserAddress();


            builder.Entity<Pet>().ConfigurePet();

            builder.Entity<PetType>().ConfigurePetType();


            builder.Entity<Product>().ConfigureProduct();

            builder.Entity<ProductImage>().ConfigureProductImage();

            builder.Entity<ProductCategory>().ConfigureProductCategory();

            builder.Entity<ProductTag>().ConfigureProductTag();


            builder.Entity<Order>().ConfigureOrder();

            builder.Entity<OrderItem>().ConfigureOrdersItem();

            builder.Entity<OrderStatus>().ConfigureOrderStatus();


            builder.Entity<Provider>().ConfigureProvider();

            builder.Entity<ProviderItem>().ConfigureProviderItem();


            builder.Entity<ShoppingCart>().ConfigureShoppingCart();

            builder.Entity<ShoppingCartItem>().ConfigureShoppingCartItem();




        }
    }
}
