using EmptyParcelLocker.API.Data.Models;

namespace EmptyParcelLocker.API.MockData;

public static class CoordinatesMockData
{
    private static readonly Random Random = new();
    
    public static List<Coordinates> GetAllCoordinates()
    {
        return new List<Coordinates>
        {
            new Coordinates {Id = Guid.NewGuid(), X = Random.Next(-180, 181), Y = Random.Next(-90, 91)},
            new Coordinates {Id = Guid.NewGuid(), X = Random.Next(-180, 181), Y = Random.Next(-90, 91)},
            new Coordinates {Id = Guid.NewGuid(), X = Random.Next(-180, 181), Y = Random.Next(-90, 91)},
        };
    }

    public static List<Coordinates> GetEmptyCoordinatesList()
    {
        return new List<Coordinates>();
    }
}