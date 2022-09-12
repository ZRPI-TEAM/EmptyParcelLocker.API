using System.Collections.ObjectModel;
using EmptyParcelLocker.API.Data.Models;

namespace EmptyParcelLocker.API.MockData;

public static class ParcelLockerMockData
{
    private static readonly Random _random = new();

    public static List<ParcelLocker> GetParcelLockers(int parcelLockersQuantity, int lockersPerParcelLocker)
    {
        throw new NotImplementedException();
    }

    public static List<ParcelLocker> GetEmptyParcelLockerList()
    {
        return new List<ParcelLocker>();
    }
}