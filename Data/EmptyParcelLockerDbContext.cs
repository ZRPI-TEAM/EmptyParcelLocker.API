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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParcelLocker>().HasKey(p => p.Id);
        modelBuilder.Entity<ParcelLocker>().HasMany<Locker>().WithOne(l => l.ParcelLocker).HasForeignKey(p => p.ParcelLocerId);
        
        modelBuilder.Entity<Locker>().HasKey(p => p.Id);
        modelBuilder.Entity<Locker>().HasOne<ParcelLocker>().WithMany(p => p.Lockers).HasForeignKey(p => p.ParcelLocerId);
        modelBuilder.Entity<Locker>().HasOne<LockerType>().WithMany(l => l.Lockers).HasForeignKey(p => p.LockerTypeId);

        modelBuilder.Entity<LockerType>().HasKey(l => l.Id);

        var smallLocker = new LockerType
        {
            Id = Guid.NewGuid(),
            Name = "small",
            MaxHeight = 80,
            MaxWidth = 380,
            MaxLength = 640,
            MaxWeight = 25
        };

        var mediumLocker = new LockerType
        {
            Id = Guid.NewGuid(),
            Name = "medium",
            MaxHeight = 190,
            MaxWidth = 380,
            MaxLength = 640,
            MaxWeight = 25
        };

        var largeLocker = new LockerType()
        {
            Id = Guid.NewGuid(),
            Name = "large",
            MaxHeight = 410,
            MaxWidth = 380,
            MaxLength = 640,
            MaxWeight = 25
        };

        var lockerTypes = new[] {smallLocker, mediumLocker, largeLocker};

        var parcelLockerKrakow = CreateNewParcelLocker("KRA000", "Kwiatowa;11;u8;Krakow;00-000");
        parcelLockerKrakow.Lockers = CreateLockersForParcelLocker(parcelLockerKrakow, lockerTypes);

        var parcelLockerLublin = CreateNewParcelLocker("LUB001", "Smieszna;12;3b;Lublin;11-111");
        parcelLockerLublin.Lockers = CreateLockersForParcelLocker(parcelLockerLublin, lockerTypes);

        var parcelLockerKatowice = CreateNewParcelLocker("KAT003", "Kolejowa;13;u4;Katowice;22-222");
        parcelLockerKatowice.Lockers = CreateLockersForParcelLocker(parcelLockerKatowice, lockerTypes);

        var parcelLockerWarszawa = CreateNewParcelLocker("WAR004", "Hanysowa;14;q7;Warszawa;33-333");
        parcelLockerWarszawa.Lockers = CreateLockersForParcelLocker(parcelLockerWarszawa, lockerTypes);

        var parcelLockers = new[] {parcelLockerKrakow, parcelLockerLublin, parcelLockerKatowice, parcelLockerWarszawa};

        var allLockers = new List<Locker>();
        allLockers.AddRange(parcelLockerKrakow.Lockers);
        allLockers.AddRange(parcelLockerLublin.Lockers);
        allLockers.AddRange(parcelLockerKatowice.Lockers);
        allLockers.AddRange(parcelLockerWarszawa.Lockers);

        modelBuilder.Entity<LockerType>().HasData(lockerTypes);
        modelBuilder.Entity<Locker>().HasData(allLockers);
        modelBuilder.Entity<ParcelLocker>().HasData(parcelLockers);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<ParcelLocker?> ParcelLockers { get; set; }
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