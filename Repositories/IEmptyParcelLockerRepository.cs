using EmptyParcelLocker.API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Repositories;

public interface IEmptyParcelLockerRepository
{
    // Parcel Lockers
    Task<List<ParcelLocker>> GetParcelLockersAsync();
    Task<ParcelLocker?> GetParcelLockerAsync(Guid parcelLockerId);
    Task<IActionResult> UpdateParcelLockerAsync(ParcelLocker parcelLocker);
    Task<Coordinates> GetParcelLockerCoordinatesAsync(Guid parcelLockerId);
    
    // Lockers
    Task<List<Locker>> GetLockersAsync();
    Task<Locker?> GetLockerAsync(Guid lockerId);
    Task UpdateLockerAsync(Locker locker);
    Task<IActionResult> UpdateLockerEmptyStatusAsync(Guid lockerId, bool isEmpty);
    
    // LockerTypes
    Task<List<LockerType>> GetLockerTypesAsync();
    Task<LockerType?> GetLockerTypeAsync(Guid lockerTypeId);
    Task UpdateLockerTypeAsync(LockerType lockerType);
}