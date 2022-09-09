using System.Collections.ObjectModel;
using EmptyParcelLocker.API.Data.Models;

namespace EmptyParcelLocker.API.Mocker.MockData;

public static class LockerMockData
{
    private static readonly Random Random = new Random();
    
    public static ICollection<Locker> GetLockers(int quantity)
    {
        var lockerTypes = LockerTypeMockData.GetLockerTypes();
        var lockers = new Collection<Locker>();

        for (var i = 0; i < quantity; i++)
        {
            var randomLockerType = lockerTypes[Random.Next(0, 3)];
            var locker = new Locker
            {
                Id = Guid.NewGuid(),
                IsEmpty = Random.Next(0, 100) % 2 == 0,
                LockerType = randomLockerType,
                LockerTypeId = randomLockerType.Id,
            };
            
            lockers.Add(locker);
        }

        return lockers;
    }

    public static Locker GetLocker()
    {
        var lockerTypes = LockerTypeMockData.GetLockerTypes();
        var randomLockerType = lockerTypes[Random.Next(0, 3)];
        var locker = new Locker
        {
            Id = Guid.NewGuid(),
            IsEmpty = Random.Next(0, 100) % 2 == 0,
            LockerType = randomLockerType,
            LockerTypeId = randomLockerType.Id,
            ParcelLocerId = Guid.NewGuid(),
        };

        return locker;
    }
}