using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Pointman.CarRental.Company.API.Models;

namespace Pointman.CarRental.Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private static readonly List<Models.Company> Companies = new List<Models.Company>
        {
            new Models.Company { Id = 1, Name = "BlueRent", Location = "Warszawa", TelephoneNumber = "+48 123 456 789" },
            new Models.Company { Id = 2, Name = "GreenRent", Location = "Katowice", TelephoneNumber = "+48 123 456 789" },
            new Models.Company { Id = 3, Name = "BlackRent", Location = "Wrocław", TelephoneNumber = "+48 123 456 789" },
            new Models.Company {Id = 4, Name = "YellowRent", Location = "Kraków", TelephoneNumber = "+48 987 654 321"},
            new Models.Company { Id = 5, Name = "BlackRent", Location = "Szczecin", TelephoneNumber = "+48 999 456 789" },
            new Models.Company { Id = 6, Name = "WhiteRent", Location = "Wrocław", TelephoneNumber = "+48 562 456 789" },

        };

        [HttpGet]
        public ActionResult<IEnumerable<Models.Company>> GetCompanies()
        {
            return Companies;
        }


        [HttpGet("{id}")]
        public ActionResult<Models.Company> GetCompany(int id)
        {
            var company = Companies.FirstOrDefault(c => c.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            return company;
        }
    }
}
