using Microsoft.EntityFrameworkCore;
using Sensores.Radix.Domain.Entity;

namespace Sensores.Radix.Infra.Data.DbContexts
{

    public class SensorEventContext : DbContext
    {
        public SensorEventContext(DbContextOptions<SensorEventContext> options) : base(options) { }
        public DbSet<SensorEvent> SensorEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SensorEventContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
