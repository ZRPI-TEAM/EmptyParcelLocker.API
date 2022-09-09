using EmptyParcelLocker.API.Data.Models;
using EmptyParcelLocker.API.Services;
using EmptyParcelLocker.API.Mocker.MockData;

namespace EmptyParcelLocker.API.Data;

public class EmptyParcelLockerDbSeeder
{
    private readonly Random _random = new();
    private readonly IEmptyParcelLockerService _emptyParcelLockerService;

    public EmptyParcelLockerDbSeeder(IEmptyParcelLockerService emptyParcelLockerService)
    {
        _emptyParcelLockerService = emptyParcelLockerService;
    }

    public async Task SeedAsync()
    {
        foreach (var lockerType in LockerTypeMockData.GetLockerTypes())
        {
            await _emptyParcelLockerService.UpdateLockerTypeAsync(lockerType);
        }
        
        var parcelLockerCieszyn = new ParcelLocker
        {
            Id = Guid.Parse("22e88beb-98bb-4922-adba-538e86f5834b"),
            Name = "CSZ08M",
            Address = "Frysztacka;61;;43-400;Cieszyn",
            Coordinates = new Coordinates
            {
                Id = Guid.NewGuid(),
                X = 49.75750794284093, 
                Y = 18.62290616610615,
            },
            Lockers = LockerMockData.GetLockers(30),
        };
        await AddParcelLockerWithLockersToDatabaseAsync(parcelLockerCieszyn);

        var parcelLockersQuantity = 10;
        var lockersPerParcelLocker = 15;
        var parcelLockers = ParcelLockerMockData.GetParcelLockers(parcelLockersQuantity, lockersPerParcelLocker);
        
        foreach (var parcelLocker in parcelLockers)
        {
            await AddParcelLockerWithLockersToDatabaseAsync(parcelLocker);
        }
    }

    private async Task AddParcelLockerWithLockersToDatabaseAsync(ParcelLocker parcelLocker)
    {
        foreach (var locker in parcelLocker.Lockers)
        {
            await _emptyParcelLockerService.UpdateLockerAsync(locker);
        }

        await _emptyParcelLockerService.UpdateParcelLockerAsync(parcelLocker);
    }
}