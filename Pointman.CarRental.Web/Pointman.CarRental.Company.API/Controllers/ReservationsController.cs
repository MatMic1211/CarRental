using Microsoft.AspNetCore.Mvc;
using Pointman.CarRental.Company.API.Mappers;
using Pointman.CarRental.Company.API.Services;
using Pointman.CarRental.Company.API.ViewModels;

namespace Pointman.CarRental.Company.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IReservationMapper _reservationMapper;

        public ReservationsController(IReservationService reservationService, IReservationMapper reservationMapper)
        {
            _reservationService = reservationService;
            _reservationMapper = reservationMapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var reservation = _reservationMapper.MapToModel(viewModel);
            await _reservationService.AddReservationAsync(reservation);
            return Ok(new { message = "Rezerwacja zapisana pomyślnie." });
        }
    }

}
