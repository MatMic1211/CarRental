using System.ComponentModel.DataAnnotations;

namespace Pointman.CarRental.Company.API.Models
{
    public class CarViewModel : EntityViewModel
    {
        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }
    }
}
