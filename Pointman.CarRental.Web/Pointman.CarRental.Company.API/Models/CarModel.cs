using Pointman.CarRental.Company.API.Models;

namespace Pointman.CarRental.Company.API.Entities
{
    public class CarModel
    {
        public int Id { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public int BrandId { get; set; } 
        public string Type { get; set; } = string.Empty;
        public int ProductionYear { get; set; }

        public int NumberOfSeats { get; set; }

        public CarBrand Brand { get; set; }
        public ICollection<CarVersion> CarVersions { get; set; } = new List<CarVersion>();
    }
}
