using System;
using Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Portion> Portions { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}