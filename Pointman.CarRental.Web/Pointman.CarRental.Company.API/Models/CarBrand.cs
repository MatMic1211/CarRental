using Pointman.CarRental.Company.API.Entities;

public class CarBrand
{
    public int Id { get; set; }
    public string BrandName { get; set; } = string.Empty;
    public ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
}
