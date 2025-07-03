using Microsoft.EntityFrameworkCore;
using Pointman.CarRental.Company.API.Entities;

namespace Pointman.CarRental.Company.API.Services
{
    public class CarService : ICarService
    {
        private readonly CompanyContext _context;

        public CarService(CompanyContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> AddCarAsync(Car car)
        {
            _context.Cars.Add(car);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Car> GetCarByModelAsync(string model)
        {
            return await _context.Cars.FirstOrDefaultAsync(c => c.Model == model);
        }

        public async Task<bool> UpdateCarAsync(int id, Car car)
        {
            var existingCar = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCar == null)
                return false;

            existingCar.Model = car.Model;
            existingCar.Brand = car.Brand;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
                return false;

            _context.Cars.Remove(car);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<Car>> GetCarsPagedAsync(int pageNumber, int pageSize)
        {
            return await _context.Cars
                .OrderBy(c => c.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<(List<Car> Items, int TotalCount)> GetPagedCarsAsync(int pageNumber, int pageSize)
        {
            var query = _context.Cars.AsQueryable();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(c => c.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

    }
}
