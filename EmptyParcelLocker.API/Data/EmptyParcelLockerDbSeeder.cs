using EmptyParcelLocker.API.Data.Models;
using EmptyParcelLocker.API.MockData;
using EmptyParcelLocker.API.Services;
using EmptyParcelLocker.API.Repositories;
using Microsoft.AspNetCore.Identity;

namespace EmptyParcelLocker.API.Data;

public static class EmptyParcelLockerDbSeeder
{
    public static void SeedDatabase(IEmptyParcelLockerRepository emptyParcelLockerRepository, int parcelLockersQuantity = 10, int
        lockersPerParcelLocker = 5)
    {
        // Locker Types
        if (emptyParcelLockerRepository.GetLockerTypesAsync().Result.Count < 1)
        {
            var lockerTypes = LockerTypeMockData.GetLockerTypes();
            SeedLockerTypes(emptyParcelLockerRepository, lockerTypes);    
        }
        
        // ParcelLockers
        // TODO: Uncomment to enable seeding parcel lockers
        
        // if (emptyParcelLockerRepository.GetParcelLockersAsync().Result.Count < 1)
        // {
        //     var mockedParcelLockers = ParcelLockerMockData.GetParcelLockers(parcelLockersQuantity, lockersPerParcelLocker);
        //     SeedParcelLockers(emptyParcelLockerRepository, mockedParcelLockers);    
        // }

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
            Lockers = new List<Locker>(),
        };

        if (emptyParcelLockerRepository.GetParcelLockerAsync(parcelLockerCieszyn.Id).Result == null)
        {
            foreach (var locker in LockerMockData.GetLockers(30))
            {
                parcelLockerCieszyn.Lockers.Add(
                    new Locker
                    {
                        Id = locker.Id,
                        IsEmpty = locker.IsEmpty,
                        LockerTypeId = locker.LockerTypeId,
                        ParcelLockerId = parcelLockerCieszyn.Id
                    });
            }
        
            SeedCustomParcelLocker(emptyParcelLockerRepository, parcelLockerCieszyn);
        }
    }

    public static void SeedCustomParcelLocker(IEmptyParcelLockerRepository emptyParcelLockerRepository, ParcelLocker parcelLocker)
    {
        emptyParcelLockerRepository.UpdateParcelLockerAsync(parcelLocker).Wait();
        foreach (var locker in parcelLocker.Lockers)
        {
            emptyParcelLockerRepository.UpdateLockerAsync(locker).Wait();
        }

        emptyParcelLockerRepository.UpdateCoordinatesAsync(parcelLocker.Coordinates);
    }

    public static void SeedParcelLockers(IEmptyParcelLockerRepository emptyParcelLockerRepository, List<ParcelLocker>
        parcelLockers)
    {
        foreach (var parcelLocker in parcelLockers)
        {
        //     emptyParcelLockerRepository.UpdateCoordinatesAsync(parcelLocker.Coordinates).Wait();
        //
        //     emptyParcelLockerRepository.UpdateLockersAsync(parcelLocker.Lockers.ToList()).Wait();

            emptyParcelLockerRepository.UpdateParcelLockerAsync(parcelLocker).Wait();
        }
    }

    public static void SeedLockerTypes(IEmptyParcelLockerRepository emptyParcelLockerRepository, List<LockerType> lockerTypes)
    {
        foreach (var lockerType in lockerTypes)
        {
            emptyParcelLockerRepository.UpdateLockerTypeAsync(lockerType).Wait();
        }
    }
}