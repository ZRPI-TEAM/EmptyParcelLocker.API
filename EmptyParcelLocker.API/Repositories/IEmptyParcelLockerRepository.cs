using EmptyParcelLocker.API.Data.Models;

namespace EmptyParcelLocker.API.Repositories;

public interface IEmptyParcelLockerRepository
{
    // ParcelLocker
    Task<List<ParcelLocker>> GetParcelLockersAsync();
    Task<ParcelLocker?> GetParcelLockerAsync(Guid parcelLockerId);
    
    // Locker
    Task<List<Locker>> GetLockersOfParcelLockerAsync(Guid parcelLockerId);
    Task<Locker> UpdateLockerEmptyStatusAsync(Guid lockerId, bool isEmpty);
    Task<Locker?> GetLockerAsync(Guid lockerId);
    
    // Address
    Task<Address> GetAddressAsync(Guid addressId);
    
    // LockerType
    Task<LockerType> GetLockerTypeAsync(Guid lockerTypeId);
}