using System;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(x => x.Weight)
                .IsRequired(false);
            builder.Property(x => x.OwnerId)
                .IsRequired();
            builder.Property(x => x.BirthDay)
                .IsRequired(false);
            builder.HasMany<Portion>(x => x.Portions)
                .WithOne(x => x.Pet);

            builder.HasData(new Pet
            {
                Id = Guid.Parse(StaticValues.BasyaId),
                Name = StaticValues.BasyaName,
                Weight = 2,
                BirthDay = DateTime.Parse("12/10/2020"),
                OwnerId = Guid.Parse(StaticValues.AdminUserId)
            });
        }
    }
}