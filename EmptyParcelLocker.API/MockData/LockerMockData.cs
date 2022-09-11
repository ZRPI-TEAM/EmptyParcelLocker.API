using System.Collections.ObjectModel;
using EmptyParcelLocker.API.Data.Models;

namespace EmptyParcelLocker.API.MockData;

public static class LockerMockData
{
    private static readonly Random Random = new Random();
    
    public static List<Locker> GetLockers(int quantity)
    {
        var lockerTypes = LockerTypeMockData.GetLockerTypes();
        var lockers = new List<Locker>();

        for (var i = 0; i < quantity; i++)
        {
            var randomLockerType = lockerTypes.ToList()[Random.Next(0, 3)];
            var locker = new Locker
            {
                Id = Guid.NewGuid(),
                IsEmpty = Random.Next(0, 100) % 2 == 0,
                LockerTypeId = randomLockerType.Id,
            };
            
            lockers.Add(locker);
        }

        return lockers;
    }

    public static Locker GetLocker()
    {
        var lockerTypes = LockerTypeMockData.GetLockerTypes();
        var randomLockerType =  lockerTypes.ToList()[Random.Next(0, 3)];
        var locker = new Locker
        {
            Id = Guid.NewGuid(),
            IsEmpty = Random.Next(0, 100) % 2 == 0,
            LockerTypeId = randomLockerType.Id,
            ParcelLockerId = Guid.NewGuid(),
        };

        return locker;
    }

    public static List<Locker> GetEmptyLockersList()
    {
        return new List<Locker>();
    }
}