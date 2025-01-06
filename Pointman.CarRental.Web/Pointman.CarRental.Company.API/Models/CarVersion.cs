using Pointman.CarRental.Company.API.Entities;

public class CarVersion
{
    public int Id { get; set; }
    public string VersionName { get; set; } = string.Empty;
    public string DriveType { get; set; } = string.Empty;
    public int HorsePower { get; set; }
    public double Acceleration { get; set; }

    public int ModelId { get; set; }
    public CarModel Model { get; set; }
}
