using System.ComponentModel.DataAnnotations;

namespace Pointman.CarRental.Company.API.Entities
{
    public class UserPermission
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
