using Microsoft.EntityFrameworkCore;
using Pointman.CarRental.Company.API.Entities;
using Pointman.CarRental.Company.API.Models;

namespace Pointman.CarRental.Company.API.Services
{
    public class ReservationService : IReservationService
    {
        private readonly CompanyContext _context;

        public ReservationService(CompanyContext context)
        {
            _context = context;
        }

        public async Task AddReservationAsync(Reservation reservation)
        {
            bool isAvailable = await IsCarAvailableAsync(reservation.CarId, reservation.StartDate, reservation.EndDate);
            if (!isAvailable)
            {
                throw new InvalidOperationException("Samochód jest już zarezerwowany w podanym terminie.");
            }

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsCarAvailableAsync(int carId, DateTime startDate, DateTime endDate)
        {
            return !await _context.Reservations.AnyAsync(r =>
                r.CarId == carId &&
                (
                    (startDate >= r.StartDate && startDate <= r.EndDate) ||
                    (endDate >= r.StartDate && endDate <= r.EndDate) ||
                    (startDate <= r.StartDate && endDate >= r.EndDate)
                )
            );
        }
    }
}
