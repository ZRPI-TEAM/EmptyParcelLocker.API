using EmptyParcelLocker.API.Data;
using EmptyParcelLocker.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmptyParcelLocker.API.Repositories;

public class SqlEmptyParcelLockerRepository : IEmptyParcelLockerRepository
{
    private readonly EmptyParcelLockerDbContext _context;

    public SqlEmptyParcelLockerRepository(EmptyParcelLockerDbContext context)
    {
        _context = context;
    }

    public async Task<List<ParcelLocker>> GetParcelLockersAsync()
    {
        return await _context.ParcelLockers.Include(nameof(Locker)+'s').ToListAsync();
    }

    public async Task<ParcelLocker?> GetParcelLockerAsync(Guid parcelLockerId)
    {
        return await _context.ParcelLockers
            .Include(nameof(Locker)+'s')
            .FirstOrDefaultAsync(p => p.Id == parcelLockerId);
    }

    public async Task UpdateParcelLockerAsync(ParcelLocker parcelLocker)
    {
        if (_context.ParcelLockers.Any(p => p.Id == parcelLocker.Id))
        {
            var existingParcelLocker = await _context.ParcelLockers
                .Include(nameof(Locker)+'s')
                .FirstAsync(p => p.Id == parcelLocker.Id);
            
            // existingParcelLocker.Lockers = parcelLocker.Lockers;
            existingParcelLocker.Name = parcelLocker.Name;
            existingParcelLocker.Address = parcelLocker.Address;
            existingParcelLocker.Lockers = parcelLocker.Lockers;
        }
        else
        {
            await _context.ParcelLockers.AddAsync(parcelLocker);
        }
        
        await _context.SaveChangesAsync();
    }

    public async Task<List<Locker>> GetLockersAsync()
    {
        return await _context.Lockers.Include(nameof(ParcelLocker)+'s').ToListAsync();
    }

    public async Task<Locker?> GetLockerAsync(Guid lockerId)
    {
        return await _context.Lockers.FirstOrDefaultAsync(l => l.Id == lockerId);
    }

    public async Task UpdateLockerAsync(Locker locker)
    {
        if (_context.Lockers.Any(l => l.Id == locker.Id))
        {
            var existingLocker = await _context.Lockers
                .Include(nameof(ParcelLocker)+'s')
                .Include(nameof(LockerType)+'s')
                .FirstAsync(l => l.Id == locker.Id);

            existingLocker.IsEmpty = locker.IsEmpty;
            existingLocker.LockerType = locker.LockerType;
            existingLocker.LockerTypeId = locker.LockerTypeId;
            existingLocker.ParcelLocker = locker.ParcelLocker;
            existingLocker.ParcelLocerId = locker.ParcelLocerId;
        }
        else
        {
            await _context.Lockers.AddAsync(locker);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<List<LockerType>> GetLockerTypesAsync()
    {
        return await _context.LockerTypes.ToListAsync();
    }

    public async Task<LockerType?> GetLockerTypeAsync(Guid lockerTypeId)
    {
        return await _context.LockerTypes.FirstOrDefaultAsync(lt => lt.Id == lockerTypeId);
    }
}