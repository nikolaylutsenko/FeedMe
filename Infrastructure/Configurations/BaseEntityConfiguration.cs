using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Id)
                .HasDefaultValueSql("newid()")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.HasKey(x => x.Id);
        }
    }
}