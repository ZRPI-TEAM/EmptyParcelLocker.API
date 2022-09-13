using EmptyParcelLocker.API.Data;
using EmptyParcelLocker.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmptyParcelLocker.API.Repositories;

public class SqlEmptyParcelLockerRepository : IEmptyParcelLockerRepository
{
    private readonly EmptyParcelLockerDbContext _dbContext;

    public SqlEmptyParcelLockerRepository(EmptyParcelLockerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ParcelLocker>> GetParcelLockersAsync()
    {
        return await _dbContext.ParcelLockers.ToListAsync();
    }

    public async Task<ParcelLocker?> GetParcelLockerAsync(Guid parcelLockerId)
    {
        return await _dbContext.ParcelLockers.FirstOrDefaultAsync(p => p.Id == parcelLockerId);
    }

    public async Task<List<Locker>> GetLockersOfParcelLockerAsync(Guid parcelLockerId)
    {
        return await _dbContext.Lockers.Where(l => l.ParcelLockerId == parcelLockerId).ToListAsync();
    }

    public async Task<Locker> UpdateLockerEmptyStatusAsync(Guid lockerId, bool isEmpty)
    {
        var existingLocker = await _dbContext.Lockers.FirstAsync(l => l.Id == lockerId);
        existingLocker.IsEmpty = isEmpty;
        await _dbContext.SaveChangesAsync();
        
        return await _dbContext.Lockers.FirstAsync(l => l.Id == lockerId);
    }

    public async Task<Locker?> GetLockerAsync(Guid lockerId)
    {
        return await _dbContext.Lockers.FirstOrDefaultAsync(l => l.Id == lockerId);
    }

    public async Task<Address> GetAddressAsync(Guid addressId)
    {
        return await _dbContext.Addresses.FirstAsync(a => a.Id == addressId);
    }

    public async Task<LockerType> GetLockerTypeAsync(Guid lockerTypeId)
    {
        return await _dbContext.LockerTypes.FirstAsync(l => l.Id == lockerTypeId);
    }
}