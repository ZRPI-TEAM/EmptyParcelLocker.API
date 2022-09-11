using System.Collections.ObjectModel;
using EmptyParcelLocker.API.Data;
using EmptyParcelLocker.API.Data.Models;
using Microsoft.AspNetCore.Mvc;
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
        return await _context.ParcelLockers.ToListAsync();
    }

    public async Task<ParcelLocker?> GetParcelLockerAsync(Guid parcelLockerId)
    {
        var parcelLocker = await _context.ParcelLockers.FirstOrDefaultAsync(p => p.Id == parcelLockerId);
        parcelLocker.Lockers = await _context.Lockers.Where(l => l.ParcelLockerId == parcelLocker.Id).ToListAsync();

        return parcelLocker;
    }

    public async Task<ParcelLocker> UpdateParcelLockerAsync(ParcelLocker parcelLocker)
    {
        if (_context.ParcelLockers.Any(p => p.Id == parcelLocker.Id))
        {
            var existingParcelLocker = await _context.ParcelLockers.FirstAsync(p => p.Id == parcelLocker.Id);

            // existingParcelLocker.Lockers = parcelLocker.Lockers;
            existingParcelLocker.Name = parcelLocker.Name;
            existingParcelLocker.Address = parcelLocker.Address;
            existingParcelLocker.Lockers = parcelLocker.Lockers;
            existingParcelLocker.Coordinates = parcelLocker.Coordinates;
        }
        else
        {
            await _context.ParcelLockers.AddAsync(parcelLocker);
        }

        await _context.SaveChangesAsync();

        return await _context.ParcelLockers.FirstAsync(p => p.Id == parcelLocker.Id);
    }

    public async Task<Coordinates> GetParcelLockerCoordinatesAsync(Guid parcelLockerId)
    {
        var parcelLocker = await _context.ParcelLockers.FirstOrDefaultAsync(p => p.Id == parcelLockerId);

        if (parcelLocker == null)
        {
            throw new NullReferenceException();
        }

        return parcelLocker.Coordinates;
    }

    public async Task<List<Locker>> UpdateParcelLockerLockersAsync(Guid parcelLockerId, List<Locker> lockers)
    {
        var parcelLocker = await _context.ParcelLockers.FirstOrDefaultAsync(p => p.Id == parcelLockerId);
        if(parcelLocker == null)
        {
            throw new KeyNotFoundException($"Could not get parcelLocker of Id {parcelLockerId}");
        }

        foreach (var locker in lockers)
        {
            locker.ParcelLockerId = parcelLockerId;
        }
        parcelLocker.Lockers = lockers;

        await _context.SaveChangesAsync();

        return lockers;
    }

    public async Task<List<Locker>> GetLockersAsync()
    {
        var lockers = await _context.Lockers.ToListAsync();
        return lockers;
    }

    public async Task<Locker?> GetLockerAsync(Guid lockerId)
    {
        var locker = await _context.Lockers.FirstOrDefaultAsync(l => l.Id == lockerId);
        return locker;
    }

    public async Task UpdateLockerAsync(Locker locker)
    {
        if (await _context.Lockers.AnyAsync(l => l.Id == locker.Id))
        {
            var existingLocker = await _context.Lockers.FirstAsync(l => l.Id == locker.Id);
            existingLocker.IsEmpty = locker.IsEmpty;
            existingLocker.LockerTypeId = locker.LockerTypeId;
            existingLocker.ParcelLockerId = locker.ParcelLockerId;
        }
        else
        {
            await _context.Lockers.AddAsync(locker);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<List<Locker>> UpdateLockersAsync(List<Locker> lockers)
    {
        foreach (var locker in lockers)
        {
            if(_context.Lockers.Any(l => l.Id == locker.Id)) continue;

            _context.Lockers.Add(locker);
        }

        return await _context.Lockers.ToListAsync();
    }

    public async Task<List<LockerType>> GetLockerTypesAsync()
    {
        return await _context.LockerTypes.ToListAsync();
    }

    public async Task<LockerType?> GetLockerTypeAsync(Guid lockerTypeId)
    {
        return await _context.LockerTypes.FirstOrDefaultAsync(lt => lt.Id == lockerTypeId);
    }

    public async Task UpdateLockerTypeAsync(LockerType lockerType)
    {
        if (_context.LockerTypes.Any(lt => lt.Id == lockerType.Id))
        {
            var existingLockerType = await _context.LockerTypes
                .FirstAsync(lt => lt.Id == lockerType.Id);

            existingLockerType.Name = lockerType.Name;
            existingLockerType.MaxHeight = lockerType.MaxHeight;
            existingLockerType.MaxLength = lockerType.MaxLength;
            existingLockerType.MaxWeight = lockerType.MaxWeight;
            existingLockerType.MaxWidth = lockerType.MaxWidth;
        }
        else
        {
            await _context.LockerTypes.AddAsync(lockerType);
        }

        await _context.SaveChangesAsync();
    }

    public async Task UpdateCoordinatesAsync(Coordinates coordinates)
    {
        var existingCoordinates = await _context.Coordinates.FirstOrDefaultAsync(c => c.Id == coordinates.Id);
        if (existingCoordinates != null)
        {
            existingCoordinates.Id = coordinates.Id;
            existingCoordinates.X = coordinates.X;
            existingCoordinates.Y = coordinates.Y;
        }
        else
        {
            _context.Coordinates.Add(coordinates);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<List<Coordinates>> GetCoordinatesAsync()
    {
        return await _context.Coordinates.ToListAsync();
    }

    public async Task<IActionResult> UpdateLockerEmptyStatusAsync(Guid lockerId, bool isEmpty)
    {
        var locker = await _context.Lockers.FirstOrDefaultAsync(l => l.Id == lockerId);

        if (locker == null)
        {
            return new NotFoundResult();
        }
        
        locker.IsEmpty = isEmpty;
        await _context.SaveChangesAsync();
        
        return new OkResult();
    }
}