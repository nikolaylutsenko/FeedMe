using System;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();

            builder.HasData(new AppUser
            {
                Id = Guid.Parse(StaticValues.AdminUserId),
                UserName = "Admin",
                NormalizedUserName = "Admin".ToUpper(),
                Email = StaticValues.AdminUserEmail,
                NormalizedEmail = StaticValues.AdminUserEmail.ToUpper(),
                ConcurrencyStamp = StaticValues.AdminUserId,
                PasswordHash = "AQAAAAEAACcQAAAAEEClBxq6oh/8fiBfjff6gQKaxj9waQ209eomjVCablbdV4NiD3ZLF/p4uMSaxLAXXQ==",
                SecurityStamp = StaticValues.AdminUserId
            });
        }
    }

    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();
        }
    }
}