using Microsoft.AspNetCore.Mvc;
using Pointman.CarRental.Company.API.Entities;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (_context.Users.Any(u => u.Email == model.Email))
            {
                return BadRequest(new { message = "Użytkownik o podanym adresie email już istnieje." });
            }

            var user = new UserRegistration
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Użytkownik został zarejestrowany." });
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

    public class RegisterModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
