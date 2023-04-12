using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<IdentityRole>(entity =>
        //    {
        //        entity.ToTable("Roles");
        //    });

        //    builder.Entity<IdentityRoleClaim<string>>(entity =>
        //    {
        //        entity.ToTable("Permissions");
        //    });
        //}

        public DbSet<User>? Users { get; set; }
        public DbSet<Item>? Items { get; set; }
        public DbSet<ItemCategory>? ItemCategory { get; set; }
        public DbSet<Unit>? Unit { get; set; }
        public DbSet<Supplier>? Suppliers { get; set; }
        public DbSet<Inbound>? Inbounds { get; set; }
        public DbSet<Outbound>? Outbounds { get; set; }
    }
}
