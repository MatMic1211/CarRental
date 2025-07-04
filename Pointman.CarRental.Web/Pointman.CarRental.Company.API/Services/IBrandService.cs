namespace Pointman.CarRental.Company.API.Services
{
    public interface IBrandService
    {
        Task<List<string>> GetAllBrandsAsync();
    }
}
