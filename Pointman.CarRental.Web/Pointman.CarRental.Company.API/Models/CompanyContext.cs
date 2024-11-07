using Microsoft.EntityFrameworkCore;

namespace Pointman.CarRental.Company.API.Entities
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }

        public DbSet<RentCompany> RentCompanies { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentCompany>()
                .HasOne(r => r.Location)      
                .WithOne(l => l.RentCompany)    
                .HasForeignKey<Location>(l => l.RentCompanyId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
