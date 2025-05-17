using Pointman.CarRental.Company.API.Entities;
using Pointman.CarRental.Company.API.Models;

namespace Pointman.CarRental.Company.API.Mappers
{
    public interface ICarMapper
    {
        CarViewModel ToViewModel(Car car);
        Car ToEntity(CarViewModel model);
    }
}
