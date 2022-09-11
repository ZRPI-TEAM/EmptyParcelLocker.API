using EmptyParcelLocker.API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Repositories;

public interface IEmptyParcelLockerRepository
{
    // Parcel Lockers
    Task<List<ParcelLocker>> GetParcelLockersAsync();
    Task<ParcelLocker?> GetParcelLockerAsync(Guid parcelLockerId);
    Task<ParcelLocker> UpdateParcelLockerAsync(ParcelLocker parcelLocker);
    Task<Coordinates> GetParcelLockerCoordinatesAsync(Guid parcelLockerId);
    Task<List<Locker>> UpdateParcelLockerLockersAsync(Guid parcelLockerId, List<Locker> lockers);

    // Lockers
    Task<List<Locker>> GetLockersAsync();
    Task<Locker?> GetLockerAsync(Guid lockerId);
    Task UpdateLockerAsync(Locker locker);
    Task<IActionResult> UpdateLockerEmptyStatusAsync(Guid lockerId, bool isEmpty);
    Task<List<Locker>> UpdateLockersAsync(List<Locker> lockers);
    
    // LockerTypes
    Task<List<LockerType>> GetLockerTypesAsync();
    Task<LockerType?> GetLockerTypeAsync(Guid lockerTypeId);
    Task UpdateLockerTypeAsync(LockerType lockerType);

    // Coordinates
    Task UpdateCoordinatesAsync(Coordinates coordinates);
    Task<List<Coordinates>> GetCoordinatesAsync();
}