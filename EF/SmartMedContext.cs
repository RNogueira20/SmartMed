using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class SmartMedContext : DbContext
    {
        public SmartMedContext(DbContextOptions<SmartMedContext> options) : base(options)
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Medication> Medications { get; set; }
    }
}
