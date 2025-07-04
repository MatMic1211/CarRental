using Pointman.CarRental.Company.API.Models;
using Pointman.CarRental.Company.API.ViewModels;

namespace Pointman.CarRental.Company.API.Mappers
{
    public interface IBrandMapper
    {
        BrandViewModel ToViewModel(string brand);
    }
}
