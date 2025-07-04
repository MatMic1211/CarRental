using Pointman.CarRental.Company.API.ViewModels;

namespace Pointman.CarRental.Company.API.Mappers
{
    public class BrandMapper : IBrandMapper
    {
        public BrandViewModel ToViewModel(string brand)
        {
            return new BrandViewModel { Name = brand };
        }
    }
}
