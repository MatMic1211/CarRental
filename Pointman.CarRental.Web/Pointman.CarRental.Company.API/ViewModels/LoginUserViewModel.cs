using System.ComponentModel.DataAnnotations;

namespace Pointman.CarRental.Company.API.ViewModels
{
    public class LoginUserViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
