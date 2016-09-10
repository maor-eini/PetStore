﻿using Microsoft.EntityFrameworkCore;
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
                .WithOne()
                .IsRequired()
                .HasForeignKey<Product>(p => p.CategoryId)
                .HasPrincipalKey<ProductCategory>(pc => pc.Id);

            b.HasMany(p => p.Images)
                .WithOne(pi => pi.Product)
                .IsRequired()
                .HasForeignKey(pi => pi.Id);

            b.HasMany(p => p.Tags)
                .WithOne(pt => pt.Product)
                .IsRequired()
                .HasForeignKey(pt => pt.ProductId);
        }

        public static void ConfigureProductCategory(this EntityTypeBuilder<ProductCategory> b)
        {
            b.ToTable("Category","Product");

            b.HasKey(pc => pc.Id);

        }

        public static void ConfigureProductImage(this EntityTypeBuilder<ProductImage> b)
        {
            b.ToTable("Images", "Product");

            b.HasKey(pc => pc.Id);           
        }

        public static void ConfigureProductTag(this EntityTypeBuilder<ProductTag> b)
        {
            b.ToTable("Tags", "Product");

            b.HasKey(pc => pc.Id);

        }
    }
}