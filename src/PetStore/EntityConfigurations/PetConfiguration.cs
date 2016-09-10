using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.EntityConfigurations
{
    public static class PetConfiguration
    {
        public static void ConfigurePet(this EntityTypeBuilder<Pet> b)
        {
            b.ToTable("Pets", "Pet");

            b.HasKey(p => p.Id);

            b.HasOne(p => p.Type)
                .WithMany(pt => pt.Pets)
                .HasForeignKey(p => p.TypeId)
                .HasPrincipalKey(pt => pt.Id)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
