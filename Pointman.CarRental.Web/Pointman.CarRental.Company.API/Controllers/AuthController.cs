using Microsoft.AspNetCore.Mvc;
using Pointman.CarRental.Company.API.Entities;
using System.Linq;

namespace Pointman.CarRental.Company.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly CompanyContext _context;

        public AuthController(CompanyContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Users
                .Where(u => u.Id == id)
                .Select(u => new
                {
                    u.Id,
                    u.Email,
                    u.FirstName,
                    u.LastName,
                    Roles = u.Roles.Select(r => new
                    {
                        r.Id,
                        r.Name,
                        Permissions = r.Permissions.Select(p => p.Name).ToList()
                    }).ToList()
                })
                .FirstOrDefault();

            if (user == null)
            {
                return NotFound(new { message = "Użytkownik nie został znaleziony" });
            }

            return Ok(user);
        }
    }
}
