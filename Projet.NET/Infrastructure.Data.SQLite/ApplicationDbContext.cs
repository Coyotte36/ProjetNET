using Shared.ApiModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Infrastructure.Data.SQLite
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<MaintenanceModel>()
                .HasKey(x => x.Id);

            modelBuilder
                .Entity<ModelModel>()
                .HasKey(x => x.Id);

            modelBuilder
                .Entity<VehicleModel>()
                .HasKey(x => x.Id);
        }
    }
}
