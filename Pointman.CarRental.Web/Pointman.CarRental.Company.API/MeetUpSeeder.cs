using Pointman.CarRental.Company.API.Entities;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pointman.CarRental.Company.API
{
    public class MeetUpSeeder
    {
        private readonly CompanyContext _companyContext;

        public MeetUpSeeder(CompanyContext meetupContext)
        {
            _companyContext = meetupContext;
        }

        public void Seed()
        {
            if (_companyContext.Database.CanConnect())
            {
                if (!_companyContext.Meetups.Any())
                {
                    InsertSampleData();
                }
            }
        }

        private void InsertSampleData()
        {
            var meetups = new List<Entities.Company>
            {
                new Entities.Company
                {
                    Name = "RedRent",
                    Location = new Location
                    {
                        City = "Wrocław",
                    }
                },
                new Entities.Company
                {
                    Name = "BlueRent",
                    Location = new Location
                    {
                        City = "Katowice",
                    }
                },
                new Entities.Company
                {
                    Name = "GreenRent",
                    Location = new Location
                    {
                        City = "Wrocław",
                    }
                }
            };

            _companyContext.Meetups.AddRange(meetups);
            _companyContext.SaveChanges();
        }
    }
}
