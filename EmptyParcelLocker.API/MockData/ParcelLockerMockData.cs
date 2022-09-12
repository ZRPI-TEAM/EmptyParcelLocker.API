using System.Collections.ObjectModel;
using EmptyParcelLocker.API.Data.Models;

namespace EmptyParcelLocker.API.MockData;

public static class ParcelLockerMockData
{
    private static readonly Random _random = new();

    public static List<ParcelLocker> GetParcelLockers(int parcelLockersQuantity, int lockersPerParcelLocker)
    {
        var parcelLockers = new List<ParcelLocker>();

        for (var i = 0; i < parcelLockersQuantity; i++)
        {
            var mockedCoordinates = CoordinatesMockData.GetCoordinates();
            var parcelLocker = new ParcelLocker
            {
                Id = Guid.NewGuid(),
                Name = $"ParcelLocker{0}",
                Address = $"street{0};houseNumber{0};ApartmentNumber{0};{0}{0}-{0}{0}{0};City{0}",
                Coordinates = mockedCoordinates,
                Lockers = new List<Locker>(),
            };

            parcelLocker.Coordinates.ParcelLockerId = parcelLocker.Id;

            var mockedLockers = LockerMockData.GetLockers(lockersPerParcelLocker);
            foreach (var locker in mockedLockers)
            {
                parcelLocker.Lockers.Add(new Locker
                {
                    Id = locker.Id,
                    IsEmpty = locker.IsEmpty,
                    LockerTypeId = locker.LockerTypeId,
                    ParcelLockerId = parcelLocker.Id
                });
            }

            parcelLockers.Add(parcelLocker);
        }

        return parcelLockers;
    }

    public static List<ParcelLocker> GetEmptyParcelLockerList()
    {
        return new List<ParcelLocker>();
    }
}