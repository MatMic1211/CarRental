using Pointman.CarRental.Company.API.Entities;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pointman.CarRental.Company.API
{
    public class MeetUpSeeder
    {
        private readonly CarRentalContext _companyContext;

        public MeetUpSeeder(CarRentalContext companyContext)
        {
            _companyContext = companyContext;
        }

        public void Seed()
        {
            if (_companyContext.Database.CanConnect())
            {
                if (!_companyContext.RentCompanies.Any())
                {
                    InsertSampleData();
                }
            }
        }

        private void InsertSampleData()
        {
            var meetups = new List<RentCompany>
            {
                new RentCompany
                {
                    Name = "RedRent",
                    Location = new Location
                    {
                        City = "Wrocław",
                    }
                },
                new RentCompany
                {
                    Name = "BlueRent",
                    Location = new Location
                    {
                        City = "Katowice",
                    }
                },
                new RentCompany
                {
                    Name = "GreenRent",
                    Location = new Location
                    {
                        City = "Wrocław",
                    }
                }
            };

            _companyContext.RentCompanies.AddRange(meetups);
            _companyContext.SaveChanges();
        }
    }
}
