using System.ComponentModel.DataAnnotations;

namespace Pointman.CarRental.Company.API.Entities
{
    public class RentCompany
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ?Name { get; set; }

        [Required]
        public string? TelephoneNumber { get; set; }

        [Required]
        public virtual Location? Location { get; set; }

    }
}
