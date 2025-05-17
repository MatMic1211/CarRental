using Pointman.CarRental.Company.API.Entities;
using Pointman.CarRental.Company.API.Models;

namespace Pointman.CarRental.Company.API.Mappers
{
    public class CarMapper : ICarMapper
    {
        public CarViewModel ToViewModel(Car car)
        {
            return new CarViewModel
            {
                Id = car.Id,
                Model = car.Model,
                Brand = car.Brand
            };
        }

        public Car ToEntity(CarViewModel model)
        {
            return new Car
            {
                Id = model.Id,
                Model = model.Model,
                Brand = model.Brand
            };
        }
    }
}
