using Shared.ApiModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Server.Domain;

namespace Infrastructure.Data.SQLite
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {

        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Maintenance>()
                .HasKey(x => x.Id);

            modelBuilder
                .Entity<Model>()
                .HasKey(x => x.Id);

            modelBuilder
                .Entity<Vehicle>()
                .HasKey(x => x.Id);
        }
    }
}
