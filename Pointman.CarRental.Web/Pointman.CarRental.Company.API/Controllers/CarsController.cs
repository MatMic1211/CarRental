using Microsoft.AspNetCore.Mvc;
using Pointman.CarRental.Company.API.Entities;

namespace Pointman.CarRental.Company.API.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly CompanyContext _context;

        public CarsController(CompanyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _context.Cars.ToList();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound(new { Message = "Car not found" });
            }
            return Ok(car);
        }


        [HttpPost]
        public IActionResult AddCar([FromBody] Car newCar)
        {
            if (newCar == null || string.IsNullOrEmpty(newCar.Model) || string.IsNullOrEmpty(newCar.Brand))
            {
                return BadRequest(new { Message = "Invalid data" });
            }
            _context.Cars.Add(newCar);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCarById), new { id = newCar.Id }, newCar);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound(new { Message = "Car not found" });
            }

            _context.Cars.Remove(car); 
            _context.SaveChanges(); 

            return NoContent(); 
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody] Car updatedCar)
        {
            if (updatedCar == null || string.IsNullOrEmpty(updatedCar.Model) || string.IsNullOrEmpty(updatedCar.Brand))
            {
                return BadRequest(new { Message = "Invalid data" });
            }

            var car = _context.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound(new { Message = "Car not found" });
            }

            car.Model = updatedCar.Model;
            car.Brand = updatedCar.Brand;
            _context.Cars.Update(car);
            _context.SaveChanges();

            return Ok(car);
        }
    }
}
