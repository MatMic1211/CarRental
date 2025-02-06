using Microsoft.AspNetCore.Mvc;
using Pointman.CarRental.Company.API.Entities;
using Pointman.CarRental.Company.API.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Pointman.CarRental.Company.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private static readonly List<User> Users = new()
        {
            new User { Id = 1, UserName = "Mateusz Miczulski", Role = UserRole.Admin },
            new User { Id = 2, UserName = "Piotr Miczulski", Role = UserRole.CompanyOwner }
        };

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { message = "Użytkownik nie został znaleziony" });
            }

            var permissions = RolePermissions.Permissions[user.Role]
                .Select(p => GetPermissionCode(p)) 
                .ToList();

            var userData = new
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = user.Role.ToString(),
                Permissions = permissions
            };

            return Ok(userData);
        }

        private string GetPermissionCode(UserPermission permission)
        {
            FieldInfo field = permission.GetType().GetField(permission.ToString());

            var attribute = field.GetCustomAttribute<PermissionDefinitionAttribute>();

            return attribute?.Code ?? permission.ToString();
        }
    }
}
