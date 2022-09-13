using EmptyParcelLocker.API.Data.Models;

namespace EmptyParcelLocker.API.Domain.Models;

public class Locker
{
    public Guid Id { get; set; }
    public bool IsEmpty { get; set; }
    public LockerType LockerType { get; set; }
    public Guid ParcelLockerId { get; set; }
}