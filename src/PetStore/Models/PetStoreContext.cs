using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetStore.EntityConfigurations;

namespace PetStore.Models
{
    public class PetStoreContext : IdentityDbContext<UserAccount>
    {
        public PetStoreContext(DbContextOptions<PetStoreContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
   
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("ApplicationData");

            builder.Entity<IdentityUser>().ConfigureIdentityUser();

            builder.Entity<IdentityRole>().ConfigureIdentityRole();

            builder.Entity<IdentityUserRole<string>>().ConfigureIdentityUserRole();

            builder.Entity<IdentityUserLogin<string>>().ConfigureIdentityUserLogin();

            builder.Entity<IdentityUserToken<string>>().ConfigureIdentityUserToken();

            builder.Entity<IdentityUserClaim<string>>().ConfigureIdentityUserClaim();

            builder.Entity<IdentityRoleClaim<string>>().ConfigureIdentityRoleClaim();


            builder.Entity<UserAccount>().ConfigureUser();

            builder.Entity<UserAddress>().ConfigureUserAddress();

            builder.Entity<UserImage>().ConfigureUserImage();


            builder.Entity<Product>().ConfigureProduct();

            builder.Entity<ProductImage>().ConfigureProductImage();

            builder.Entity<ProductCategory>().ConfigureProductCategory();

            builder.Entity<ProductTag>().ConfigureProductTag();


            builder.Entity<Order>().ConfigureOrder();

            builder.Entity<OrderItem>().ConfigureOrdersItem();


            builder.Entity<Provider>().ConfigureProvider();

            builder.Entity<ProviderItem>().ConfigureProviderItem();


            builder.Entity<ShoppingCart>().ConfigureShoppingCart();

            builder.Entity<ShoppingCartItem>().ConfigureShoppingCartItem();




        }
    }
}
