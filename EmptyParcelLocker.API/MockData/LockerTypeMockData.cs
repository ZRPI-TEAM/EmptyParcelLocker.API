using System.Collections.ObjectModel;
using EmptyParcelLocker.API.Data.Models;

namespace EmptyParcelLocker.API.MockData;

public static class LockerTypeMockData
{
    public static List<LockerType> GetLockerTypes()
    {
        return new List<LockerType>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "small",
                MaxHeight = 80,
                MaxWidth = 380,
                MaxLength = 640,
                MaxWeight = 25
            },
            
            new()
            {
                Id = Guid.NewGuid(),
                Name = "medium",
                MaxHeight = 190,
                MaxWidth = 380,
                MaxLength = 640,
                MaxWeight = 25
            },
            
            new()
            {
                Id = Guid.NewGuid(),
                Name = "large",
                MaxHeight = 410,
                MaxWidth = 380,
                MaxLength = 640,
                MaxWeight = 25
            },
        };
    }

    public static List<LockerType> GetEmptyLockerTypes()
    {
        return new List<LockerType>();
    }
}