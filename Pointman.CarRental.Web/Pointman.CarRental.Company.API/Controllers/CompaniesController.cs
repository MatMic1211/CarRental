using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pointman.CarRental.Company.API.Models;
using Pointman.CarRental.Company.API.Services;
using Pointman.CarRental.Company.API.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pointman.CarRental.Company.API.Mappers;

namespace Pointman.CarRental.Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CompaniesController : ControllerBase
    {
        private readonly CompanyService _companyService;
        private readonly IRentCompanyMapper _rentCompanyMapper;

        public CompaniesController(CompanyService companyService, IRentCompanyMapper rentCompanyMapper)
        {
            _companyService = companyService;
            _rentCompanyMapper = rentCompanyMapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentCompanyViewModel>>> GetCompanies()
        {
            var companies = await _companyService.GetAllCompaniesAsync();
            var viewModels = companies.Select(_rentCompanyMapper.ToViewModel);
            return Ok(viewModels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentCompanyViewModel>> GetCompany(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null)
                return NotFound();

            var viewModel = _rentCompanyMapper.ToViewModel(company);
            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult<RentCompanyViewModel>> AddCompany([FromBody] RentCompanyViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _rentCompanyMapper.ToEntity(model);
            var result = await _companyService.AddCompanyAsync(entity);

            if (!result)
                return StatusCode(500, "Failed to add company.");

            var newCompany = await _companyService.GetCompanyByNameAsync(model.Name);
            var newViewModel = _rentCompanyMapper.ToViewModel(newCompany);

            return CreatedAtAction(nameof(GetCompany), new { id = newCompany.Id }, newViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] RentCompanyViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _rentCompanyMapper.ToEntity(model);
            var result = await _companyService.UpdateCompanyAsync(id, entity);
            return result ? NoContent() : StatusCode(500, "Failed to update company.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var result = await _companyService.DeleteCompanyAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
