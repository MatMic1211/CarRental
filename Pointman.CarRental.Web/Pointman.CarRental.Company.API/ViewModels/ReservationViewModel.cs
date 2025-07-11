namespace Pointman.CarRental.Company.API.ViewModels
{
    public class ReservationViewModel
    {
        public int CarId { get; set; }
        public string CustomerName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartTime { get; set; } = null!;
        public string EndTime { get; set; } = null!;
        public string PickupLocation { get; set; } = null!;
        public string ReturnLocation { get; set; } = null!;
    }
}
