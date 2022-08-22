using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmptyParcelLocker.API.Data.Models;

public class ParcelLockerAddress
{
    [Key]
    public Guid Id { get; set; }

    [Required] 
    public string Street { get; set; }
    
    [Required] 
    public string StreetNumber { get; set; }
    
    public string? ApartmentNumber { get; set; }
    
    [Required] 
    public string ZipCode { get; set; }
    
    [Required] 
    public string CityName { get; set; }
    
    [ForeignKey(nameof(ParcelLocker))]
    public Guid ParcelLockerId { get; set; }
    public virtual ParcelLocker ParcelLocker { get; set; }
    
}