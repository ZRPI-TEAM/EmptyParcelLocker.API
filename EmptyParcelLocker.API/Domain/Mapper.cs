using EmptyParcelLocker.API.Services.Locker;
using EmptyParcelLocker.API.Services.ParcelLocker;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using DataModels = EmptyParcelLocker.API.Data.Models;
using DomainModels = EmptyParcelLocker.API.Domain.Models;

namespace EmptyParcelLocker.API.Domain;

public static class Mapper
{
    public static async Task<DomainModels.ParcelLocker> MapParcelLockerAsync(DataModels.ParcelLocker source, IParcelLockerService parcelLockerService)
    {
        return new DomainModels.ParcelLocker
        {
            Id = source.Id,
            Name = source.Name,
            Address = await parcelLockerService.GetAddressAsync(source.Id),
            Latitude = source.Latitude,
            Longitude = source.Longitude
        };
    }

    public static async Task<DomainModels.Locker> MapLockerAsync(DataModels.Locker source, ILockerService lockerService)
    {
        return new DomainModels.Locker
        {
            Id = source.Id,
            IsEmpty = source.IsEmpty,
            LockerType = await lockerService.GetLockerTypeAsync(source.Id),
            ParcelLockerId = source.ParcelLockerId
        };
    }

    public static async Task<List<DomainModels.Locker>> MapLockerListAsync(List<DataModels.Locker> lockers, ILockerService lockerService)
    {
        var mappedLockers = new List<DomainModels.Locker>();
        foreach (var locker in lockers)
        {
            var mappedLocker = await MapLockerAsync(locker, lockerService);
            mappedLockers.Add(mappedLocker);
        }

        return mappedLockers;
    }

    public static async Task<List<DomainModels.ParcelLocker>> MapParcelLockerList(List<DataModels.ParcelLocker> parcelLockerList,
        IParcelLockerService parcelLockerService)
    {
        var mappedParcelLockers = new List<DomainModels.ParcelLocker>();
        foreach (var parcelLocker in parcelLockerList)
        {
            var mappedParcelLocker = await MapParcelLockerAsync(parcelLocker, parcelLockerService);
            mappedParcelLockers.Add(mappedParcelLocker);
        }

        return mappedParcelLockers;
    }
}