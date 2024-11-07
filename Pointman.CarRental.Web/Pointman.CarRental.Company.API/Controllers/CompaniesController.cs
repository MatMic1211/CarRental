using Microsoft.AspNetCore.Mvc;
using Pointman.CarRental.Company.API.Models;
using Pointman.CarRental.Company.API.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointman.CarRental.Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly CompanyService _companyService;

        public CompaniesController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentCompanyViewModel>>> GetCompanies()
        {
            var companies = await _companyService.GetAllCompaniesAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentCompanyViewModel>> GetCompany(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }
    }
}
