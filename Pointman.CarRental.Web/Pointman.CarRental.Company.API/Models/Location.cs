namespace Pointman.CarRental.Company.API.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string? City { get; set; }

        public int RentCompanyId { get; set; }
        public virtual RentCompany? RentCompany { get; set; }

        public int MeetupId { get; set; }
    }
}