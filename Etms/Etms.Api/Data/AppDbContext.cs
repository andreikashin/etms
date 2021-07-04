using Etms.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Etms.Api.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(p => p.Username)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Ignore(u => u.Token);


            modelBuilder.Entity<Role>()
                .HasData(new[]
                {
                    new Role {Id = 1, Name = "Admin"},
                    new Role {Id = 2, Name = "User"},
                });
        }
    }
}
