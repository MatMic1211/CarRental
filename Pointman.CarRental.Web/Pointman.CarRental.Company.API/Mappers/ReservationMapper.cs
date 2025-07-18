using Pointman.CarRental.Company.API.Models;
using Pointman.CarRental.Company.API.ViewModels;

namespace Pointman.CarRental.Company.API.Mappers
{
    public class ReservationMapper : IReservationMapper
    {
        public Reservation MapToModel(ReservationViewModel viewModel)
        {
            return new Reservation
            {
                CarId = viewModel.CarId,
                CustomerName = viewModel.CustomerName,
                Email = viewModel.Email, 
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                StartTime = viewModel.StartTime,
                EndTime = viewModel.EndTime,
                PickupLocation = viewModel.PickupLocation,
                ReturnLocation = viewModel.ReturnLocation
            };
        }
    }
}
