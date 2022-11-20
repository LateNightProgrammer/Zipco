using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;
using Persistence.SeedData;

namespace Persistence
{
    public class ZipcoContext : DbContext
    {
        public ZipcoContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new PopulateTestDataUser());
            modelBuilder.ApplyConfiguration(new PopulateTestDataAccount());
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Account { get; set; }
        
    }
}
