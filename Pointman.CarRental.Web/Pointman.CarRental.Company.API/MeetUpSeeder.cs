using Pointman.CarRental.Company.API.Entities;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pointman.CarRental.Company.API
{
    public class MeetUpSeeder
    {
        private readonly CompanyContext _companyContext;

        public MeetUpSeeder(CompanyContext companyContext)
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
            var rentCompanies = new List<RentCompany>
    {
        new RentCompany
        {
            Name = "RedRent",
            TelephoneNumber = "123-456-789",
            Location = new Location
            {
                City = "Wrocław"
            }
        },
        new RentCompany
        {
            Name = "BlueRent",
            TelephoneNumber = "987-654-321",
            Location = new Location
            {
                City = "Katowice"
            }
        },
        new RentCompany
        {
            Name = "GreenRent",
            //TelephoneNumber = "456-123-789",
            Location = new Location
            {
                City = "Wrocław"
            }
        },
          new RentCompany
        {
            Name = "BlackRent",
            TelephoneNumber = "142-212-122",
            Location = new Location
            {
                City = "Wrocław"
            }
        }
    };
            _companyContext.RentCompanies.AddRange(rentCompanies);
            _companyContext.SaveChanges();
        }
    }
}
