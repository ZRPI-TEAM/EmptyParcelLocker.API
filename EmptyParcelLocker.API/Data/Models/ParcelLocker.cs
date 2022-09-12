using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmptyParcelLocker.API.Data.Models;

public class ParcelLocker
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; }
    [ForeignKey(nameof(Address))] public Guid AddressId { get; set; }
    [ForeignKey(nameof(Coordinates))] public Guid CoordinatesId { get; set; }
}