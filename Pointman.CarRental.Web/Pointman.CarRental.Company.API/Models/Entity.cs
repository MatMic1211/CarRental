using System.ComponentModel.DataAnnotations;

namespace Pointman.CarRental.Company.API.Models
{
    public class Entity
    {
        [Required]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
