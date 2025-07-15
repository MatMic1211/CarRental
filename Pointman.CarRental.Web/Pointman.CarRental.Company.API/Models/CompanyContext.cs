using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pointman.CarRental.Company.API.Models;

namespace Pointman.CarRental.Company.API.Entities
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }

        public DbSet<RentCompany> RentCompanies { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<UserRegistration> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Reservation> Reservations { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var utcConverter = new ValueConverter<DateTime, DateTime>(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
            );

            modelBuilder.Entity<Car>()
                .Property(c => c.CreatedOn)
                .HasConversion(utcConverter);

            modelBuilder.Entity<UserRegistration>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserUserRoles",
                    j => j.HasOne<UserRole>().WithMany().HasForeignKey("UserRoleId"),
                    j => j.HasOne<UserRegistration>().WithMany().HasForeignKey("UserId"),
                    j => j.HasKey("UserId", "UserRoleId")
                );

            modelBuilder.Entity<UserRole>()
                .HasMany(r => r.Permissions)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "UserRolePermissions",
                    j => j.HasOne<UserPermission>().WithMany().HasForeignKey("UserPermissionId"),
                    j => j.HasOne<UserRole>().WithMany().HasForeignKey("UserRoleId"),
                    j => j.HasKey("UserRoleId", "UserPermissionId")
                );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, Name = "User" },
                new UserRole { Id = 2, Name = "Admin" }
            );

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Car)
                .WithMany()
                .HasForeignKey(r => r.CarId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
