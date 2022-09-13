using EmptyParcelLocker.API.Data.Models;
using Microsoft.AspNetCore.Routing.Tree;
using Microsoft.EntityFrameworkCore;

namespace EmptyParcelLocker.API.Data;

public class EmptyParcelLockerDbContext : DbContext
{
    public EmptyParcelLockerDbContext(DbContextOptions<EmptyParcelLockerDbContext> options) : base(options)
    {
    }

    public DbSet<ParcelLocker> ParcelLockers { get; set; }
    public DbSet<Locker> Lockers { get; set; }
    public DbSet<LockerType> LockerTypes { get; set; }
    public DbSet<Address> Addresses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var lockerTypes = new LockerType[]
        {
            new LockerType
            {
                Id = Guid.Parse("c5622830-eb07-455b-8c42-8dcbd6c8c926"),
                Name = "small",
                MaxHeight = 80,
                MaxWidth = 380,
                MaxLength = 640,
                MaxWeight = 25,
            },
            new LockerType
            {
                Id = Guid.Parse("09b9faae-6598-4e47-bce6-37cdfb46b7bf"),
                Name = "medium",
                MaxHeight = 190,
                MaxWidth = 380,
                MaxLength = 640,
                MaxWeight = 25
            },
            new LockerType
            {
                Id = Guid.Parse("f4dd7a2e-90e9-4cab-b7dc-38a6ad528403"),
                Name = "large",
                MaxHeight = 410,
                MaxWidth = 380,
                MaxLength = 640,
                MaxWeight = 25
            }
        };
        modelBuilder.Entity<LockerType>().HasData(lockerTypes);

        var newAddress = new Address
        {
            Id = Guid.Parse("dd39b1e1-e3f8-436e-9956-1d1ee8de3aa3"),
            Street = "Frysztacka",
            BuildingNumber = "61",
            ApartmentNumber = "",
            ZipCode = "43-400",
            CityName = "Cieszyn",
        };
        modelBuilder.Entity<Address>().HasData(newAddress);

        var parcelLockerCieszyn = new ParcelLocker
        {
            Id = Guid.Parse("22e88beb-98bb-4922-adba-538e86f5834b"),
            Name = "CSZ08M",
            AddressId = Guid.Parse("dd39b1e1-e3f8-436e-9956-1d1ee8de3aa3"),
            Latitude = 49.75750794284093,
            Longitude = 18.62290616610615
        };
        modelBuilder.Entity<ParcelLocker>().HasData(parcelLockerCieszyn);

        var lockers = new Locker[]
        {
            new Locker
            {
                Id = Guid.Parse("3f68494a-434a-4d7a-b047-bceec0eff40a"),
                IsEmpty = true,
                LockerTypeId = Guid.Parse("c5622830-eb07-455b-8c42-8dcbd6c8c926"),
                ParcelLockerId = parcelLockerCieszyn.Id
            },
            new Locker
            {
                Id = Guid.Parse("50e9dae7-8a83-4a29-b89b-6083804893bf"),
                IsEmpty = false,
                LockerTypeId = Guid.Parse("c5622830-eb07-455b-8c42-8dcbd6c8c926"),
                ParcelLockerId = parcelLockerCieszyn.Id
            },
            new Locker
            {
                Id = Guid.Parse("3058f64e-ba63-460d-9013-70244f25b036"),
                IsEmpty = true,
                LockerTypeId = Guid.Parse("c5622830-eb07-455b-8c42-8dcbd6c8c926"),
                ParcelLockerId = parcelLockerCieszyn.Id
            },
        };
        modelBuilder.Entity<Locker>().HasData(lockers);


        base.OnModelCreating(modelBuilder);
    }



}