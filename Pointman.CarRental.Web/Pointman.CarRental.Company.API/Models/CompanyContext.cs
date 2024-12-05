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
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentCompany>()
                .HasOne(r => r.Location)
                .WithOne(l => l.RentCompany)
                .HasForeignKey<Location>(l => l.RentCompanyId);

            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Model = "Porsche 911 GT3", Brand = "Porsche" },
                new Car { Id = 2, Model = "Lamborghini Huracan Performante", Brand = "Lamborghini" },
                new Car { Id = 3, Model = "Audi R8 Performance", Brand = "Audi" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
