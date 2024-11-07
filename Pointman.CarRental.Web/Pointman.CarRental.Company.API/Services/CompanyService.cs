using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pointman.CarRental.Company.API.Entities;
using Pointman.CarRental.Company.API.Models;

namespace Pointman.CarRental.Company.API.Services
{
    public class CompanyService
    {
        private readonly CompanyContext _context;

        public CompanyService(CompanyContext context)
        {
            _context = context;
        }

        public async Task<List<RentCompanyViewModel>> GetAllCompaniesAsync()
        {
            return await _context.RentCompanies
                .Include(c => c.Location) 
                .Select(c => new RentCompanyViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    TelephoneNumber = c.TelephoneNumber,
                    Location = c.Location.City 
                })
                .ToListAsync();
        }

        public async Task<RentCompanyViewModel> GetCompanyByIdAsync(int id)
        {
            return await _context.RentCompanies
                .Include(c => c.Location) 
                .Where(c => c.Id == id)
                .Select(c => new RentCompanyViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    TelephoneNumber = c.TelephoneNumber,
                    Location = c.Location.City 
                })
                .FirstOrDefaultAsync();
        }
    }
}
