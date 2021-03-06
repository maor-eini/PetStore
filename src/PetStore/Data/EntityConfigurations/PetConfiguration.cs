﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Models;

namespace PetStore.EntityConfigurations
{
    public static class PetConfiguration
    {
        public static void ConfigurePet(this EntityTypeBuilder<Pet> b)
        {
            b.ToTable("Pets", "Pet");

            b.HasKey(p => p.Id);

            b.HasOne(p => p.Type)
                .WithMany(pt => pt.Pet)
                .HasForeignKey(p => p.TypeId)
                .HasPrincipalKey(pt => pt.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public static void ConfigurePetType(this EntityTypeBuilder<PetType> b)
        {
            b.ToTable("PetTypes", "Pets");

            b.HasKey(p => p.Id);
        }
    }
}
