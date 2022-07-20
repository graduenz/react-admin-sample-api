using Microsoft.EntityFrameworkCore;
using ReactAdminSample.Domain.Models;

namespace ReactAdminSample.Domain
{
    public class SampleDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Trim> Trims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trim>()
                .HasOne(m => m.Model)
                .WithMany(m => m.Trims)
                .HasForeignKey(m => m.ModelId);

            modelBuilder.Entity<Model>()
                .HasOne(m => m.Make)
                .WithMany(m => m.Models)
                .HasForeignKey(m => m.MakeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
