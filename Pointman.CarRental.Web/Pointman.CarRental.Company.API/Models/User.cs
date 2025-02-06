namespace Pointman.CarRental.Company.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public UserRole Role { get; set; }
    }
}
