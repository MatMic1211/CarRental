using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pointman.CarRental.Company.API.Entities
{
    public class UserRegistration
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
    }
}
