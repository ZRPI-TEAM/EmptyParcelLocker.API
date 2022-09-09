using EmptyParcelLocker.API.Data.Models;

namespace EmptyParcelLocker.API.Mocker.MockData;

public static class LockerTypeMockData
{
    public static List<LockerType> GetLockerTypes()
    {
        return new List<LockerType>()
        {
            new()
            {
                Id = Guid.Parse("859a0307-989b-4d31-b210-9e181d12ccf0"),
                Name = "small",
                MaxHeight = 80,
                MaxWidth = 380,
                MaxLength = 640,
                MaxWeight = 25
            },
            
            new()
            {
                Id = Guid.Parse("681e1d35-9444-48e0-b78e-c5800c0ffad6"),
                Name = "medium",
                MaxHeight = 190,
                MaxWidth = 380,
                MaxLength = 640,
                MaxWeight = 25
            },
            
            new()
            {
                Id = Guid.Parse("5cd5339c-56ca-4360-bc74-e3592dc42ebb"),
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