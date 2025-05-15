using Pointman.CarRental.Company.API.Entities;
using Pointman.CarRental.Company.API.Models;

namespace Pointman.CarRental.Company.API.Mappers
{
    public interface IRentCompanyMapper
    {
        RentCompany ToEntity(RentCompanyViewModel viewModel);
        RentCompanyViewModel ToViewModel(RentCompany entity);
    }
}
