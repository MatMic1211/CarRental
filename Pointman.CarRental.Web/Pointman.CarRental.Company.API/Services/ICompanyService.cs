using Pointman.CarRental.Company.API.Entities;

namespace Pointman.CarRental.Company.API.Services
{
    public interface ICompanyService
    {
        Task<List<RentCompany>> GetAllCompaniesAsync();
        Task<RentCompany> GetCompanyByIdAsync(int id);
        Task<RentCompany> GetCompanyByNameAsync(string name);
        Task<bool> AddCompanyAsync(RentCompany model);
        Task<bool> UpdateCompanyAsync(int id, RentCompany model);
        Task<bool> DeleteCompanyAsync(int id);
    }
}
