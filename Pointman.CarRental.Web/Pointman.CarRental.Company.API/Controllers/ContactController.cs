using Microsoft.AspNetCore.Mvc;
using Pointman.CarRental.Company.API.Entities;
using Pointman.CarRental.Company.API.Models;
using Pointman.CarRental.Company.API.Mappers;
using Pointman.CarRental.Company.API.Services;
using Pointman.CarRental.Company.API.ViewModels;

namespace Pointman.CarRental.Company.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRequestMapper _mapper;
        private readonly IContactService _contactService;

        public ContactController(IContactRequestMapper mapper, IContactService contactService)
        {
            _mapper = mapper;
            _contactService = contactService;
        }

        [HttpPost]
        public IActionResult SendEmail([FromBody] ContactRequestViewModel requestViewModel)
        {
            try
            {
                var request = _mapper.MapToEntity(requestViewModel);
                _contactService.SendEmail(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
