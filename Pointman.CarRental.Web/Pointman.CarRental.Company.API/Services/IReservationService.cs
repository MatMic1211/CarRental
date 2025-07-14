using Pointman.CarRental.Company.API.Models;

namespace Pointman.CarRental.Company.API.Services
{
    public interface IReservationService
    {
        Task AddReservationAsync(Reservation reservation);
        Task<bool> IsCarAvailableAsync(int carId, DateTime startDate, DateTime endDate);
    }

}
