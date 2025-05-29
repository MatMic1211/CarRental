using System.ComponentModel.DataAnnotations;

namespace Pointman.CarRental.Company.API.Models
{
    public class RentCompanyViewModel : EntityViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
    }
}
