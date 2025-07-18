using Microsoft.EntityFrameworkCore;
using Pointman.CarRental.Company.API.Entities;
using Pointman.CarRental.Company.API.Models;

namespace Pointman.CarRental.Company.API.Services
{
    public class ReservationService : IReservationService
    {
        private readonly CompanyContext _context;
        private readonly IEmailService _emailService;

        public ReservationService(CompanyContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
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

            var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == reservation.CarId);

            var subject = "Potwierdzenie rezerwacji – RentMo";
            var body = $"Witaj {reservation.CustomerName},\n\n" +
                       $"Dziękujemy za dokonanie rezerwacji samochodu.\n\n" +
                       $"🚗 Samochód: {car?.Brand} {car?.Model}\n" +
                       $"📅 Termin: {reservation.StartDate:yyyy-MM-dd} do {reservation.EndDate:yyyy-MM-dd}\n" +
                       $"📍 Miejsce odbioru: {reservation.PickupLocation}\n" +
                       $"📍 Miejsce zwrotu: {reservation.ReturnLocation}\n\n" +
                       $"Pozdrawiamy,\nZespół RentMo";

            await _emailService.SendEmailAsync(reservation.Email, subject, body);
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
