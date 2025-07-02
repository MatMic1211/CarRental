using Pointman.CarRental.Company.API.Entities;

namespace Pointman.CarRental.Company.API.Services
{
    public interface ICarService
    {
        Task<List<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(int id);
        Task<bool> AddCarAsync(Car car);
        Task<Car> GetCarByModelAsync(string model);
        Task<bool> UpdateCarAsync(int id, Car car);
        Task<bool> DeleteCarAsync(int id);

        Task<(List<Car> Items, int TotalCount)> GetPagedCarsAsync(
            int pageNumber,
            int pageSize,
            string? searchQuery = null,
            string? brand = null,
            string? sortBy = "id",
            string? sortOrder = "asc"
        );
    }
}
