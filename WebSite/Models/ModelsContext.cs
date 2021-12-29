using System.IO;
using Microsoft.EntityFrameworkCore;

namespace WebSite.Models
{
    public class ModelsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Computer> Computers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Sqlite.db"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(o => o.Id);
            modelBuilder.Entity<User>().Property(o => o.Name).IsRequired();
            modelBuilder.Entity<User>().HasIndex(o => o.Name).IsUnique();
            modelBuilder.Entity<User>().Property(o => o.Password).IsRequired();
            
            modelBuilder.Entity<Computer>().HasKey(o => o.Id);
            modelBuilder.Entity<Computer>().Property(o => o.Name).IsRequired();
            modelBuilder.Entity<Computer>().HasIndex(o => o.Name).IsUnique();
            modelBuilder.Entity<Computer>().Property(o => o.MacAddress).IsRequired();
        }
    }
}