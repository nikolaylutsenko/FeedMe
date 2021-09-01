using System;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(new AppRole
            {
                Id = Guid.Parse(StaticValues.AdminRoleId),
                Name = "admin",
                NormalizedName = "admin".ToUpper(),
                ConcurrencyStamp = StaticValues.AdminRoleId,
                Description = "Admin role for administrative purposes"
            });
            builder.HasData(new AppRole
            {
                Id = Guid.Parse(StaticValues.UserRoleId),
                Name = "user",
                NormalizedName = "user".ToUpper(),
                ConcurrencyStamp = StaticValues.UserRoleId,
                Description = "User role for regular access rights"
            });
        }
    }
}