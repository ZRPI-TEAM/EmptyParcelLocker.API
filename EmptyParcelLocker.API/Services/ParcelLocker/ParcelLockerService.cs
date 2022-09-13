using EmptyParcelLocker.API.CustomExceptions;
using EmptyParcelLocker.API.Data.Models;
using EmptyParcelLocker.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Services.ParcelLocker;

public class ParcelLockerService : IParcelLockerService
{
    private readonly IEmptyParcelLockerRepository _repository;

    public ParcelLockerService(IEmptyParcelLockerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Data.Models.ParcelLocker>> GetAllParcelLockersAsync()
    {
        var parcelLockers = await _repository.GetParcelLockersAsync();
        if (parcelLockers.Count < 1)
        {
            throw new NoContentException();
        }

        return parcelLockers;
    }

    public async Task<bool> DoesParcelLockerExistsAsync(Guid parcelLockerId)
    {
        return await _repository.GetParcelLockerAsync(parcelLockerId) != null;
    }

    public async Task<Address> GetAddressAsync(Guid parcelLockerId)
    {
        var parcelLocker = await _repository.GetParcelLockerAsync(parcelLockerId);
        if (parcelLocker == null)
        {
            throw new NotFoundException();
        }

        var addressId = parcelLocker.AddressId;
        return await _repository.GetAddressAsync(addressId);
    }
}