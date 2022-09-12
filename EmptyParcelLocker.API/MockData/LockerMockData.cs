using System.Collections.ObjectModel;
using System.Data;
using EmptyParcelLocker.API.Data.Models;

namespace EmptyParcelLocker.API.MockData;

public static class LockerMockData
{
    private static readonly Random Random = new Random();
    
    public static List<Locker> GetLockers(int quantity)
    {
        throw new NotImplementedException();
    }

    public static Locker GetLocker()
    {
        throw new NotImplementedException();
    }

    public static List<Locker> GetEmptyLockersList()
    {
        return new List<Locker>();
    }
}