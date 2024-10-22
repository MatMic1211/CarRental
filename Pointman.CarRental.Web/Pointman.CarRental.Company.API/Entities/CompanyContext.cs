using Microsoft.EntityFrameworkCore;

namespace Pointman.CarRental.Company.API.Entities
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }

        public DbSet<Company> Meetups { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasOne(m => m.Location)
                .WithOne(m => m.Meetup);
        }
    }
}
