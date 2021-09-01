using System;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasData(new AppUserRole
            {
                RoleId = Guid.Parse(StaticValues.AdminRoleId),
                UserId = Guid.Parse(StaticValues.AdminUserId)
            });
        }
    }
}