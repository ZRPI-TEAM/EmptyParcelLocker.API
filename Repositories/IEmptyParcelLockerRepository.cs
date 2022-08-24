using EmptyParcelLocker.API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Repositories;

public interface IEmptyParcelLockerRepository
{
    // Parcel Lockers
    Task<List<ParcelLocker>> GetParcelLockersAsync();
    Task<ParcelLocker?> GetParcelLockerAsync(Guid parcelLockerId);
    Task UpdateParcelLockerAsync(ParcelLocker parcelLocker);
    
    // Lockers
    Task<List<Locker>> GetLockersAsync();
    Task<Locker?> GetLockerAsync(Guid lockerId);
    Task UpdateLockerAsync(Locker locker);
    
    // LockerTypes
    Task<List<LockerType>> GetLockerTypesAsync();
    Task<LockerType?> GetLockerTypeAsync(Guid lockerTypeId);
}