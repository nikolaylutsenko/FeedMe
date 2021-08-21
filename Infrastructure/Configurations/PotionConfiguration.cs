using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class PotionConfiguration : IEntityTypeConfiguration<Portion>
    {
        public void Configure(EntityTypeBuilder<Portion> builder)
        {
            // builder.HasOne(x => x.User)
            //     .WithMany(x => x.Portions)
            //     .HasForeignKey(x => x.Id);
        }
    }
}