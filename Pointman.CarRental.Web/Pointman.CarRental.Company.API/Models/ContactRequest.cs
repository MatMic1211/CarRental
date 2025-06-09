namespace Pointman.CarRental.Company.API.Models
{
    public class ContactRequest
    {
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public bool SendCopy { get; set; }
    }

}
