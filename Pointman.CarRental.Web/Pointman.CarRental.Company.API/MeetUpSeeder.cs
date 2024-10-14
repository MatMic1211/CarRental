using Pointman.CarRental.Company.API.Entities;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pointman.CarRental.Company.API
{
    public class MeetUpSeeder
    {
        private readonly MeetupContext _meetupContext;

        public MeetUpSeeder(MeetupContext meetupContext)
        {
            _meetupContext = meetupContext;
        }

        public void Seed()
        {
            if (_meetupContext.Database.CanConnect())
            {
                if (!_meetupContext.Meetups.Any())
                {
                    InsertSampleData();
                }
            }
        }

        private void InsertSampleData()
        {
            var meetups = new List<Meetup>
            {
                new Meetup
                {
                    Name = "RedRent",
                    Location = new Location
                    {
                        City = "Wrocław",
                    }
                },
                new Meetup
                {
                    Name = "BlueRent",
                    Location = new Location
                    {
                        City = "Katowice",
                    }
                },
                new Meetup
                {
                    Name = "GreenRent",
                    Location = new Location
                    {
                        City = "Wrocław",
                    }
                }
            };

            _meetupContext.Meetups.AddRange(meetups);
            _meetupContext.SaveChanges();
        }
    }
}
