using System.Collections.ObjectModel;
using EmptyParcelLocker.API.Data.Models;
using EmptyParcelLocker.API.Services;

namespace EmptyParcelLocker.API.Data;

public class EmptyParcelLockerDbSeeder
{
    private readonly Random _random;
    private readonly IEmptyParcelLockerService _emptyParcelLockerService;

    public EmptyParcelLockerDbSeeder(IEmptyParcelLockerService emptyParcelLockerService)
    {
        _emptyParcelLockerService = emptyParcelLockerService;
        _random = new Random();
    }

    public async Task SeedAsync()
    {
        try
        {
            await SeedLockerTypeAsync();
            await SeedParcelLockersAndLockersAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private async Task SeedParcelLockersAndLockersAsync()
    {
        var parcelLockers = await _emptyParcelLockerService.GetParcelLockersAsync();
        if (parcelLockers.Any())
            return;
        
        var parcelLockersNumber = _random.Next(10, 31);
        for (var i = 0; i < parcelLockersNumber; i++)
        {
            var parcelLocker = await CreateNewParcelLockerAsync("KRA000", new[] {"Kwiatowa", "00", "", "00-000", "Kraków"});
            await _emptyParcelLockerService.UpdateParcelLockerAsync(parcelLocker);    
        }
    }

    private async Task<ParcelLocker> CreateNewParcelLockerAsync(string parcelLockerName, string[] parcelLockerAddress)
    {
        var parcelLocker = new ParcelLocker
        {
            Id = Guid.NewGuid(),
            Name = parcelLockerName,
            Address = string.Join(';', parcelLockerAddress),
        };
        
        parcelLocker.Lockers = await CreateNewLockersCollectionAsync(parcelLocker);

        return parcelLocker;
    }

    private async Task<ICollection<Locker>> CreateNewLockersCollectionAsync(ParcelLocker parcelLocker)
    {
        var lockerTypes = await _emptyParcelLockerService.GetLockerTypesAsync();

        var lockers = new Collection<Locker>();
        var lockerNumber = _random.Next(12, 25);
        for (var i = 0; i < lockerNumber; i++)
        {
            var randomLockerType = lockerTypes[_random.Next(0, 3)];
            lockers.Add(new Locker
            {
                Id = Guid.NewGuid(), 
                IsEmpty = true, 
                LockerType = randomLockerType, 
                LockerTypeId = randomLockerType.Id,
                ParcelLocker = parcelLocker,
                ParcelLocerId = parcelLocker.Id
            });
        }
        
        return lockers;
    }

    private async Task SeedLockerTypeAsync()
    {
        var lockerTypes = await _emptyParcelLockerService.GetLockerTypesAsync();
        if (lockerTypes.Any())
            return;

        var smallLockerType = new LockerType
        {
            Id = Guid.NewGuid(),
            Name = "small",
            MaxHeight = 80,
            MaxWidth = 380,
            MaxLength = 640,
            MaxWeight = 25
        };

        var mediumLockerType = new LockerType
        {
            Id = Guid.NewGuid(),
            Name = "medium",
            MaxHeight = 190,
            MaxWidth = 380,
            MaxLength = 640,
            MaxWeight = 25
        };

        var largeLockerType = new LockerType
        {
            Id = Guid.NewGuid(),
            Name = "large",
            MaxHeight = 410,
            MaxWidth = 380,
            MaxLength = 640,
            MaxWeight = 25
        };

        await _emptyParcelLockerService.UpdateLockerTypeAsync(smallLockerType);
        await _emptyParcelLockerService.UpdateLockerTypeAsync(mediumLockerType);
        await _emptyParcelLockerService.UpdateLockerTypeAsync(largeLockerType);
    }
}