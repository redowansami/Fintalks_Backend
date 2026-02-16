using System;
using System.Collections.Generic;
using System.Text;
using Fintalks.DB.DBEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fintalks.DB
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options)
            : base(options) { }

        public DbSet<DBUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DBUser>().Property(e => e.UserName).IsRequired().HasMaxLength(10);

            base.OnModelCreating(modelBuilder);
        }
    }
}
