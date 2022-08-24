using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmptyParcelLocker.API.Data.Models;

public class Locker
{
    [Key]
    public Guid Id { get; set; }
    public bool IsEmpty { get; set; }
    
    [ForeignKey(nameof(ParcelLocker))]
    public Guid ParcelLocerId { get; set; }
    
    public ParcelLocker ParcelLocker { get; set; }
    
    [ForeignKey(nameof(LockerType))] 
    public Guid LockerTypeId { get; set; }
    public LockerType LockerType { get; set; }
}