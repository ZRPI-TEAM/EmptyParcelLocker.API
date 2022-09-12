using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmptyParcelLocker.API.Data.Models;

public class Locker
{
    [Key] public Guid Id { get; set; }
    public bool IsEmpty { get; set; }
    [ForeignKey(nameof(ParcelLocker))] public Guid ParcelLockerId { get; set; }
    [ForeignKey(nameof(LockerType))] public Guid LockerTypeId { get; set; }
}