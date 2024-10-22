namespace Pointman.CarRental.Company.API.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string City { get; set; }
        
        public virtual Company Meetup { get; set; }

        public int MeetupId { get; set; }
    }
}
