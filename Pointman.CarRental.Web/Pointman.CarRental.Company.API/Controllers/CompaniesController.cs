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

        [HttpPost]
        public async Task<ActionResult> AddCompany([FromBody] RentCompanyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _companyService.AddCompanyAsync(model);
            if (!result)
            {
                return StatusCode(500, "Failed to add company.");
            }

            var newCompany = await _companyService.GetCompanyByNameAsync(model.Name);
            return CreatedAtAction(nameof(GetCompany), new { id = newCompany.Id }, newCompany);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] RentCompanyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _companyService.UpdateCompanyAsync(id, model);
            if (!result)
            {
                return StatusCode(500, "Failed to update company.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var result = await _companyService.DeleteCompanyAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
