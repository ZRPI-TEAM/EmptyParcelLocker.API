using EmptyParcelLocker.API.Data.Models;

namespace EmptyParcelLocker.API.Mocker.MockData;

public static class ParcelLockerMockData
{
    private static readonly Random _random = new();

    public static List<ParcelLocker> GetParcelLockers(int parcelLockersQuantity, int lockersQuantity)
    {
        var parcelLockers = new List<ParcelLocker>();

        for (var i = 0; i < parcelLockersQuantity; i++)
        {
            var lockers = LockerMockData.GetLockers(lockersQuantity);

            var parcelLocker = new ParcelLocker
            {
                Id = Guid.NewGuid(),
                Name = $"ParcelLocker{i}",
                Address = $"street{i};houseNumber{i};ApartmentNumber{i};{i}{i}-{i}{i}{i};City{i}",
            };

            foreach (var locker in lockers)
            {
                locker.ParcelLocerId = parcelLocker.Id;
            }

            parcelLocker.Lockers = lockers;
            parcelLockers.Add(parcelLocker);
        }

        return parcelLockers;
    }

    public static ParcelLocker GetParcelLocker(int lockersQuantity)
    {
        var lockers = LockerMockData.GetLockers(lockersQuantity);

        var parcelLocker = new ParcelLocker
        {
            Id = Guid.NewGuid(),
            Name = $"ParcelLocker{0}",
            Address = $"street{0};houseNumber{0};ApartmentNumber{0};{0}{0}-{0}{0}{0};City{0}",
        };

        foreach (var locker in lockers)
        {
            locker.ParcelLocerId = parcelLocker.Id;
        }

        parcelLocker.Lockers = lockers;

        return parcelLocker;
    }
}