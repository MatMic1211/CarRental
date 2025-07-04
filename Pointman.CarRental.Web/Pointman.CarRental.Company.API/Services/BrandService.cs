using Microsoft.EntityFrameworkCore;
using Pointman.CarRental.Company.API.Entities;

namespace Pointman.CarRental.Company.API.Services
{
    public class BrandService : IBrandService
    {
        private readonly CompanyContext _context;

        public BrandService(CompanyContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetAllBrandsAsync()
        {
            return await _context.Cars
                .Select(c => c.Brand)
                .Distinct()
                .OrderBy(b => b)
                .ToListAsync();
        }
    }
}
