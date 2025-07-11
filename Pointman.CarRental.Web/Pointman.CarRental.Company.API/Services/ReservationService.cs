using Pointman.CarRental.Company.API.Entities;
using Pointman.CarRental.Company.API.Models;
using System;

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
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }
    }

}
