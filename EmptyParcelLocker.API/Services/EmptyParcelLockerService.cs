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

    public Task<ParcelLocker?> GetParcelLockerByCoordinatesAsync(Guid coordinatesId)
    {
        return _emptyParcelLockerRepository.GetParcelLockerByCoordinatesAsync(coordinatesId);
    }

    public async Task<List<ParcelLocker>> GetParcelLockersAsync()
    {
        return await _emptyParcelLockerRepository.GetParcelLockersAsync();
    }

    public async Task<ParcelLocker?> GetParcelLockerAsync(Guid parcelLockerId)
    {
        return await _emptyParcelLockerRepository.GetParcelLockerAsync(parcelLockerId);
    }

    public async Task<ParcelLocker> UpdateParcelLockerAsync(ParcelLocker parcelLocker)
    {
        return await _emptyParcelLockerRepository.UpdateParcelLockerAsync(parcelLocker);
    }

    public async Task<Coordinates> GetParcelLockerCoordinatesAsync(Guid parcelLockerId)
    {
        return await _emptyParcelLockerRepository.GetParcelLockerCoordinatesAsync(parcelLockerId);
    }

    public async Task<List<Locker>> UpdateParcelLockerLockersAsync(Guid parcelLockerId, List<Locker> lockers)
    {
        try
        {
            return await _emptyParcelLockerRepository.UpdateParcelLockerLockersAsync(parcelLockerId, lockers);
        }
        catch(KeyNotFoundException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<List<Locker>> GetLockersAsync()
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

    public async Task<List<Locker>> UpdateLockersAsync(List<Locker> lockers)
    {
        if (lockers.Count < 1)
        {
            throw new ArgumentNullException();
        }

        return await _emptyParcelLockerRepository.UpdateLockersAsync(lockers);
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

    public async Task UpdateCoordinatesAsync(Coordinates coordinates)
    {
        await _emptyParcelLockerRepository.UpdateCoordinatesAsync(coordinates);
    }

    public async Task<List<Coordinates>> GetCoordinatesAsync()
    {
        return await _emptyParcelLockerRepository.GetCoordinatesAsync();
    }

    public async Task<IActionResult> UpdateLockerEmptyStatusAsync(Guid lockerId, bool isEmpty)
    {
        return await _emptyParcelLockerRepository.UpdateLockerEmptyStatusAsync(lockerId, isEmpty);
    }
}