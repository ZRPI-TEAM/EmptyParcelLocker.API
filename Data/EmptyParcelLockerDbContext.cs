using System.Collections.ObjectModel;
using EmptyParcelLocker.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmptyParcelLocker.API.Data;

public class EmptyParcelLockerDbContext : DbContext
{
    private IConfiguration _configuration;

    public EmptyParcelLockerDbContext(DbContextOptions<EmptyParcelLockerDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("ParcelLockerDb"));
    }

    public DbSet<ParcelLocker> ParcelLockers { get; set; }
    public DbSet<Locker> Lockers { get; set; }
    public DbSet<LockerType> LockerTypes { get; set; }

    private List<Locker> CreateLockersForParcelLocker(ParcelLocker parcelLocker, LockerType[] lockerTypes)
    {
        var lockers = new List<Locker>();
        var rand = new Random();
        var lockerNumbers = rand.Next(12, 25);

        for (var i = 0; i < lockerNumbers; i++)
        {
            var randomLockerType = lockerTypes[rand.Next(0, 3)];
            var newLocker = new Locker
            {
                Id = Guid.NewGuid(),
                IsEmpty = true,
                LockerTypeId = randomLockerType.Id,
                LockerType = randomLockerType,
                ParcelLocerId = parcelLocker.Id,
                ParcelLocker = parcelLocker,
            };

            lockers.Add(newLocker);
        }

        return lockers;
    }

    private ParcelLocker CreateNewParcelLocker(string name, string address)
    {
        return new ParcelLocker
        {
            Id = Guid.NewGuid(),
            Name = name,
            Address = address
        };
    }
}