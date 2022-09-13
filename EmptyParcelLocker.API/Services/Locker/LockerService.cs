using EmptyParcelLocker.API.CustomExceptions;
using EmptyParcelLocker.API.Data.Models;
using EmptyParcelLocker.API.Repositories;
using EmptyParcelLocker.API.Services.ParcelLocker;

namespace EmptyParcelLocker.API.Services.Locker;

public class LockerService : ILockerService
{
    private readonly IEmptyParcelLockerRepository _repository;

    public LockerService(IEmptyParcelLockerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Data.Models.Locker>> GetLockersOfParcelLockerAsync(Guid parcelLockerId)
    {
        var parcelLockerService = new ParcelLockerService(_repository);
        var parcelLockerExists = await parcelLockerService.DoesParcelLockerExistsAsync(parcelLockerId);
        if (parcelLockerExists == false)
        {
            throw new NotFoundException();
        }

        var lockers = await _repository.GetLockersOfParcelLockerAsync(parcelLockerId);
        if (lockers.Count < 1)
        {
            throw new NoContentException();
        }

        return lockers;
    }

    public async Task<Data.Models.Locker> UpdateLockerEmptyStatusAsync(Guid lockerId, bool isEmpty)
    {
        var lockerExists = await DoesLockerExistsAsync(lockerId);

        if (lockerExists == false)
        {
            throw new NotFoundException();
        }
        
        var updatedLocker = await _repository.UpdateLockerEmptyStatusAsync(lockerId, isEmpty);
        return updatedLocker;
    }

    public async Task<LockerType> GetLockerTypeAsync(Guid lockerId)
    {
        var locker = await _repository.GetLockerAsync(lockerId);
        if (locker == null)
        {
            throw new NotFoundException();
        }

        var lockerType = await _repository.GetLockerTypeAsync(locker.LockerTypeId);
        if (lockerType == null)
        {
            throw new NotFoundException();
        }

        return lockerType;
    }

    private async Task<bool> DoesLockerExistsAsync(Guid lockerId)
    {
        return await _repository.GetLockerAsync(lockerId) != null;
    }
}