using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Pointman.CarRental.Company.API.Models;
using Pointman.CarRental.Company.API.Mappers;
using Pointman.CarRental.Company.API.Entities;
using Pointman.CarRental.Company.API.ViewModels;

namespace Pointman.CarRental.Company.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRequestMapper _mapper;

        public ContactController(IContactRequestMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult SendEmail([FromBody] ContactRequestViewModel requestViewModel)
        {
            try
            {
                ContactRequest request = _mapper.MapToEntity(requestViewModel);

                var fromAddress = new MailAddress("rentmo.contact@gmail.com", "RentMo");
                var toAddress = new MailAddress("mat.micz@wp.pl", "Mateusz");

                const string fromPassword = "ijdcrtjpyxgpkkef";
                string subject = $"[RentMo Kontakt] {request.Subject}";
                string body = $"Nadawca: {request.FromEmail}\n\nWiadomość:\n{request.Message}";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };

                using var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                };

                smtp.Send(message);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
