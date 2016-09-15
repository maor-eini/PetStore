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
        }
    }
}
