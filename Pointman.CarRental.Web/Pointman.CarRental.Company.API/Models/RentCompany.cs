namespace Pointman.CarRental.Company.API.Entities
{
    public class RentCompany
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? TelephoneNumber { get; set; } 

        public virtual Location? Location { get; set; } 
    }
}
