using System.ComponentModel.DataAnnotations;

namespace Pointman.CarRental.Company.API.Entities
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Model { get; set; } 

        [Required]
        public string Brand { get; set; } 
    }
}
