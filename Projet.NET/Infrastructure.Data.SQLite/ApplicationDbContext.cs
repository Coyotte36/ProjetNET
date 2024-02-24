using Shared.ApiModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Server.Domain;

namespace Infrastructure.Data.SQLite
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
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
