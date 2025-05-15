using Pointman.CarRental.Company.API.Entities;
using Pointman.CarRental.Company.API.Models;

namespace Pointman.CarRental.Company.API.Mappers
{
    public static class RentCompanyMapper
    {
        public static RentCompany ToEntity(RentCompanyViewModel viewModel)
        {
            return new RentCompany
            {
                Name = viewModel.Name,
                TelephoneNumber = viewModel.TelephoneNumber,
                Location = new Location
                {
                    City = viewModel.Location
                }
            };
        }

        public static RentCompanyViewModel ToViewModel(RentCompany entity)
        {
            return new RentCompanyViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                TelephoneNumber = entity.TelephoneNumber,
                Location = entity.Location?.City ?? string.Empty
            };
        }
    }
}
