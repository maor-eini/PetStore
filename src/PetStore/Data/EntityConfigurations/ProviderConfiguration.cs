using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Models;

namespace PetStore.EntityConfigurations
{
    public static class ProviderConfiguration
    {
        public static void ConfigureProvider(this EntityTypeBuilder<Provider> b)
        {

            b.ToTable("Providers", "Provider");

            b.HasKey(p => p.Id);

            b.HasMany(p => p.Products)
                .WithOne(pi => pi.Provider)
                .HasForeignKey(pi => pi.ProviderId)
                .HasPrincipalKey(p => p.Id);

        }

        public static void ConfigureProviderItem(this EntityTypeBuilder<ProviderItem> b)
        {
            b.ToTable("ProviderItems", "Provider");

            b.HasKey(pp => new { pp.ProductId, pp.ProviderId });

            //Many to Many
            b.HasOne(pi => pi.Product)
                .WithMany(p => p.Providers)
                .HasForeignKey(pi => pi.ProductId);

            b.HasOne(pi => pi.Provider)
                .WithMany(p => p.Products)
                .HasForeignKey(pi => pi.ProviderId);

        }
    }
}
