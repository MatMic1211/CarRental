using System.ComponentModel.DataAnnotations;

namespace Pointman.CarRental.Company.API.Entities
{
    public class Location
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public int RentCompanyId { get; set; }
        [Required]
        public virtual RentCompany? RentCompany { get; set; }


        //public int MeetupId { get; set; }
    }
}