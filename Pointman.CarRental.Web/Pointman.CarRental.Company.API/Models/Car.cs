using System.ComponentModel.DataAnnotations;
using Pointman.CarRental.Company.API.Models;

namespace Pointman.CarRental.Company.API.Entities
{
    public class Car : Entity
    {
        public Car()
        {
            CreatedOn = DateTime.UtcNow;
        }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Brand { get; set; }

    }
}
