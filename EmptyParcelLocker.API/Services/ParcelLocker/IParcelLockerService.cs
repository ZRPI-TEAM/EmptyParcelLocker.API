using EmptyParcelLocker.API.Data.Models;

namespace EmptyParcelLocker.API.Services.ParcelLocker;

public interface IParcelLockerService
{
    Task<List<Data.Models.ParcelLocker>> GetAllParcelLockersAsync();
    Task<bool> DoesParcelLockerExistsAsync(Guid parcelLockerId);
    Task<Address> GetAddressAsync(Guid parcelLockerId);
}