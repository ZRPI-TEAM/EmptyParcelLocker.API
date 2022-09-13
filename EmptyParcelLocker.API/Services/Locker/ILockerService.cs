using EmptyParcelLocker.API.Data.Models;

namespace EmptyParcelLocker.API.Services.Locker;

public interface ILockerService
{
    Task<List<Data.Models.Locker>> GetLockersOfParcelLockerAsync(Guid parcelLockerId);
    Task<Data.Models.Locker> UpdateLockerEmptyStatusAsync(Guid lockerId, bool isEmpty);
    Task<LockerType> GetLockerTypeAsync(Guid lockerId);
}