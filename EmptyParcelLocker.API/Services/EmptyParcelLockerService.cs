using EmptyParcelLocker.API.Data.Models;
using EmptyParcelLocker.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Services;

public class EmptyParcelLockerService : IEmptyParcelLockerService
{
    private readonly IEmptyParcelLockerRepository _emptyParcelLockerRepository;

    public EmptyParcelLockerService(IEmptyParcelLockerRepository emptyParcelLockerRepository)
    {
        _emptyParcelLockerRepository = emptyParcelLockerRepository;
    }

    public async Task<List<ParcelLocker>> GetParcelLockersAsync()
    {
        return await _emptyParcelLockerRepository.GetParcelLockersAsync();
    }

    public async Task<ParcelLocker?> GetParcelLockerAsync(Guid parcelLockerId)
    {
        return await _emptyParcelLockerRepository.GetParcelLockerAsync(parcelLockerId);
    }

    public async Task<IActionResult> UpdateParcelLockerAsync(ParcelLocker parcelLocker)
    {
        if (parcelLocker == null)
        {
            return new NotFoundResult();
        }
            
        await _emptyParcelLockerRepository.UpdateParcelLockerAsync(parcelLocker);

        return new OkResult();
    }

    public async Task<Coordinates> GetParcelLockerCoordinatesAsync(Guid parcelLockerId)
    {
        return await _emptyParcelLockerRepository.GetParcelLockerCoordinatesAsync(parcelLockerId);
    }

    public async Task<ICollection<Locker>> GetLockersAsync()
    {
        return await _emptyParcelLockerRepository.GetLockersAsync();
    }

    public async Task<Locker?> GetLockerAsync(Guid lockerId)
    {
        return await _emptyParcelLockerRepository.GetLockerAsync(lockerId);
    }

    public async Task UpdateLockerAsync(Locker locker)
    {
        if (locker == null)
        {
            throw new NullReferenceException();
        }
        
        await _emptyParcelLockerRepository.UpdateLockerAsync(locker);
    }

    public async Task<List<LockerType>> GetLockerTypesAsync()
    {
        return await _emptyParcelLockerRepository.GetLockerTypesAsync();
    }

    public async Task<LockerType?> GetLockerTypeAsync(Guid lockerTypeId)
    {
        return await _emptyParcelLockerRepository.GetLockerTypeAsync(lockerTypeId);
    }

    public async Task UpdateLockerTypeAsync(LockerType lockerType)
    {
        if (lockerType == null)
        {
            throw new NullReferenceException();
        }
        
        await _emptyParcelLockerRepository.UpdateLockerTypeAsync(lockerType);
    }

    public async Task<IActionResult> UpdateLockerEmptyStatusAsync(Guid lockerId, bool isEmpty)
    {
        return await _emptyParcelLockerRepository.UpdateLockerEmptyStatusAsync(lockerId, isEmpty);
    }
}