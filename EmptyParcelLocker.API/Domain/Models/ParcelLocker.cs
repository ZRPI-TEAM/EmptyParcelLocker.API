using EmptyParcelLocker.API.Data.Models;

namespace EmptyParcelLocker.API.Domain.Models;

public class ParcelLocker
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public Address Address { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}