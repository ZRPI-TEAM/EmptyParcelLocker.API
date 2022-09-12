namespace EmptyParcelLocker.API.Data.Models;

public class Address
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public string BuildingNumber { get; set; }
    public string ApartmentNumber { get; set; }
    public string ZipCode { get; set; }
    public string CityName { get; set; }
}