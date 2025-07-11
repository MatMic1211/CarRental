using Pointman.CarRental.Company.API.Models;
using Pointman.CarRental.Company.API.ViewModels;

namespace Pointman.CarRental.Company.API.Mappers
{
    public interface IReservationMapper
    {
        Reservation MapToModel(ReservationViewModel viewModel);
    }

}
