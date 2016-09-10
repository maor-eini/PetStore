using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Models;

namespace PetStore.EntityConfigurations
{
    public static class ShoppingCartConfiguration
    {
        public static void ConfigureShoppingCart(this EntityTypeBuilder<ShoppingCart> b)
        {
            b.ToTable("ShoppingCarts", "User");

            b.HasKey(sc => sc.Id);

            b.HasMany(sci => sci.ShoppingCartItems)
                .WithOne(sc => sc.ShoppingCart)
                .HasForeignKey(sci => sci.ShoppingCartId)
                .HasPrincipalKey(sc => sc.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public static void ConfigureShoppingCartItem(this EntityTypeBuilder<ShoppingCartItem> b)
        {
            b.ToTable("ShoppingCartItems", "User");

            b.HasKey(sci => new { sci.ShoppingCartId, sci.ProductId } );

            //Many to Many
            b.HasOne(sci => sci.Product)
                .WithMany(p => p.ShoppingCarts)
                .HasForeignKey(sci => sci.ProductId)
                .HasPrincipalKey(p=>p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            b.HasOne(sci => sci.ShoppingCart)
                .WithMany(sc => sc.ShoppingCartItems)
                .HasForeignKey(sci => sci.ShoppingCartId)
                .HasPrincipalKey(sc => sc.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
