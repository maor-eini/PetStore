using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Models;

namespace PetStore.EntityConfigurations
{
    public static class ProductConfiguration
    {
        public static void ConfigureProduct(this EntityTypeBuilder<Product> b)
        {
            b.ToTable("Products","Product");

            b.HasKey(o => o.Id);

            b.HasOne(p => p.Category)
                .WithMany(pc => pc.Products)
                .IsRequired()
                .HasForeignKey(p => p.CategoryId)
                .HasPrincipalKey(pc => pc.Id)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasMany(p => p.Images)
                .WithOne(pi => pi.Product)
                .IsRequired()
                .HasForeignKey(pi => pi.Id);
        }

        public static void ConfigureProductCategory(this EntityTypeBuilder<ProductCategory> b)
        {
            b.ToTable("Category","Product");

            b.HasKey(pc => pc.Id);

            b.HasMany(pc => pc.SubCategories)
                .WithOne(psc => psc.MainCategory)
                .HasForeignKey(psc => psc.MainCategoryId)
                .HasPrincipalKey(pc => pc.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public static void ConfigureProductSubCategory(this EntityTypeBuilder<ProductSubCategory> b)
        {
            b.ToTable("SubCategories", "Product");

            b.HasKey(psc => psc.Id);
        }

        public static void ConfigureProductImage(this EntityTypeBuilder<ProductImage> b)
        {
            b.ToTable("Images", "Product");

            b.HasKey(pc => pc.Id);           
        }
    }
}
