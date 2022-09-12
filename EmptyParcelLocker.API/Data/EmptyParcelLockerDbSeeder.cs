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
        // var parcelLockerCieszyn = new ParcelLocker
        // {
        //     Id = Guid.Parse("22e88beb-98bb-4922-adba-538e86f5834b"),
        //     Name = "CSZ08M",
        //     Address = "Frysztacka;61;;43-400;Cieszyn",
        //     Coordinates = new Coordinates
        //     {
        //         Id = Guid.NewGuid(),
        //         X = 49.75750794284093,
        //         Y = 18.62290616610615,
        //     },
        //     Lockers = new List<Locker>(),
        // };
    }
}