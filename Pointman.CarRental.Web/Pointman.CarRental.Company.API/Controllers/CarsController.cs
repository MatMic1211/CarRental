using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pointman.CarRental.Company.API.Models;
using Pointman.CarRental.Company.API.Services;
using Pointman.CarRental.Company.API.Mappers;

namespace Pointman.CarRental.Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly ICarMapper _carMapper;

        public CarsController(ICarService carService, ICarMapper carMapper)
        {
            _carService = carService;
            _carMapper = carMapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarViewModel>>> GetCars()
        {
            var cars = await _carService.GetAllCarsAsync();
            var viewModels = cars.Select(_carMapper.ToViewModel);
            return Ok(viewModels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarViewModel>> GetCar(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
                return NotFound();

            var viewModel = _carMapper.ToViewModel(car);
            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult<CarViewModel>> AddCar([FromBody] CarViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _carMapper.ToEntity(model);
            var result = await _carService.AddCarAsync(entity);

            if (!result)
                return StatusCode(500, "Failed to add car.");

            var newCar = await _carService.GetCarByModelAsync(model.Model);
            var newViewModel = _carMapper.ToViewModel(newCar);

            return CreatedAtAction(nameof(GetCar), new { id = newCar.Id }, newViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] CarViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _carMapper.ToEntity(model);
            var result = await _carService.UpdateCarAsync(id, entity);
            return result ? NoContent() : StatusCode(500, "Failed to update car.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var result = await _carService.DeleteCarAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
