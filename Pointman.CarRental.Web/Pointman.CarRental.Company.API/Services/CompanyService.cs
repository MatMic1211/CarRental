using Microsoft.EntityFrameworkCore;
using Pointman.CarRental.Company.API.Entities;


namespace Pointman.CarRental.Company.API.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyContext _context;

        public CompanyService(CompanyContext context)
        {
            _context = context;
        }

        public async Task<List<RentCompany>> GetAllCompaniesAsync()
        {
            return await _context.RentCompanies
                .Include(c => c.Location)
                .Select(c => new RentCompany
                {
                    Id = c.Id,
                    Name = c.Name,
                    TelephoneNumber = c.TelephoneNumber,
                    Location = new Location { City = c.Location.City }
                })
                .ToListAsync();
        }

        public async Task<RentCompany> GetCompanyByIdAsync(int id)
        {
            return await _context.RentCompanies
                .Include(c => c.Location)
                .Where(c => c.Id == id)
                .Select(c => new RentCompany
                {
                    Id = c.Id,
                    Name = c.Name,
                    TelephoneNumber = c.TelephoneNumber,
                    Location = new Location { City = c.Location.City }
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> AddCompanyAsync(RentCompany model)
        {
            var newCompany = new RentCompany
            {
                Name = model.Name,
                TelephoneNumber = model.TelephoneNumber,
                Location = new Location
                {
                    City = model.Location?.City
                }
            };

            _context.RentCompanies.Add(newCompany);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<RentCompany> GetCompanyByNameAsync(string name)
        {
            return await _context.RentCompanies
                .Include(c => c.Location)
                .Where(c => c.Name == name)
                .Select(c => new RentCompany
                {
                    Id = c.Id,
                    Name = c.Name,
                    TelephoneNumber = c.TelephoneNumber,
                    Location = new Location { City = c.Location.City }
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateCompanyAsync(int id, RentCompany model)
        {
            var existingCompany = await _context.RentCompanies
                .Include(c => c.Location)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (existingCompany == null)
            {
                return false;
            }

            existingCompany.Name = model.Name;
            existingCompany.TelephoneNumber = model.TelephoneNumber;

            if (existingCompany.Location == null)
            {
                existingCompany.Location = new Location { City = model.Location?.City };
            }
            else
            {
                existingCompany.Location.City = model.Location?.City;
            }

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            var company = await _context.RentCompanies.FindAsync(id);
            if (company == null)
            {
                return false;
            }

            _context.RentCompanies.Remove(company);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
