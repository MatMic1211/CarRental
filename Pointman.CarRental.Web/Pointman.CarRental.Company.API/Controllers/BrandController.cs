using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pointman.CarRental.Company.API.Mappers;
using Pointman.CarRental.Company.API.Services;
using Pointman.CarRental.Company.API.ViewModels;

namespace Pointman.CarRental.Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IBrandMapper _brandMapper;

        public BrandController(IBrandService brandService, IBrandMapper brandMapper)
        {
            _brandService = brandService;
            _brandMapper = brandMapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<BrandViewModel>>> GetBrands()
        {
            var brands = await _brandService.GetAllBrandsAsync();
            var result = brands.Select(_brandMapper.ToViewModel).ToList();
            return Ok(result);
        }
    }
}
