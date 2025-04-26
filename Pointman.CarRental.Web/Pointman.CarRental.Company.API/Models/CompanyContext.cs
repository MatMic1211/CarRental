using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Pointman.CarRental.Company.API.Entities
{
    public class CarRentalContext : DbContext
    {
        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options)
        {
        }

        public DbSet<RentCompany> RentCompanies { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<UserRegistration> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
        }
    }
}
