using Microsoft.EntityFrameworkCore;

namespace Pointman.CarRental.Company.API.Entities
{
    public class MeetupContext : DbContext
    {
        public MeetupContext(DbContextOptions<MeetupContext> options) : base(options)
        {
        }

        public DbSet<Meetup> Meetups { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meetup>()
                .HasOne(m => m.Location)
                .WithOne(m => m.Meetup);
        }
    }
}
