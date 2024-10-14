namespace Pointman.CarRental.Company.API.Entities
{
    public class Meetup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Location Location { get; set; }

    }
}
