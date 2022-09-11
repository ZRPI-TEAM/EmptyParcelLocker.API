using EmptyParcelLocker.API.Data;
using EmptyParcelLocker.API.Data.Models;
using EmptyParcelLocker.API.MockData;
using EmptyParcelLocker.API.Repositories;
using EmptyParcelLocker.API.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace EmptyParcelLocker.API.Test.DataTests;

public class EmptyParcelLockerDbSeederTests
{
    protected readonly EmptyParcelLockerDbContext _context;

    public EmptyParcelLockerDbSeederTests()
    {
        var options = new DbContextOptionsBuilder<EmptyParcelLockerDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString
            ()).Options;

        _context = new EmptyParcelLockerDbContext(options, false);

        _context.Database.EnsureCreated();
    }

    [Fact]
    public async Task SeedLockerTypes_PopulatesLockerTypeDatabaseTable()
    {
        // Arrange
        var mockedLockerTypes = LockerTypeMockData.GetLockerTypes();
        var repository = new SqlEmptyParcelLockerRepository(_context);
        
        // Act
        EmptyParcelLockerDbSeeder.SeedLockerTypes(repository, mockedLockerTypes);
        var lockerTypes = await repository.GetLockerTypesAsync();
        
        // Assert
        lockerTypes.Should().BeEquivalentTo(mockedLockerTypes);
        lockerTypes.Should().NotBeEmpty();
    }

    [Fact]
    public async Task SeedParcelLockers_PopulatesParcelLockersDatabaseTable()
    {
        // Arrange
        var parcelLockersQuantity = 5;
        var lockersPerParcelLocker = 3;
        var mockedParcelLockers = ParcelLockerMockData.GetParcelLockers(parcelLockersQuantity, lockersPerParcelLocker);
        
        var allMockedCoordinates = new List<Coordinates>();
        var allMockedLockers = new List<Locker>();

        foreach (var mockedParcelLocker in mockedParcelLockers)
        {
            allMockedCoordinates.Add(mockedParcelLocker.Coordinates);
            allMockedLockers.AddRange(mockedParcelLocker.Lockers.ToList());
        }
        
        var repository = new SqlEmptyParcelLockerRepository(_context);

        // Act
        EmptyParcelLockerDbSeeder.SeedParcelLockers(repository, mockedParcelLockers);
        var parcelLockers = await repository.GetParcelLockersAsync();
        var coordinates = await repository.GetCoordinatesAsync();
        var lockers = await repository.GetLockersAsync();

        // Assert
        parcelLockers.Should().NotBeNullOrEmpty();
        parcelLockers.Should().HaveCount(parcelLockersQuantity);
        parcelLockers.Should().BeEquivalentTo(mockedParcelLockers);
        foreach (var parcelLocker in parcelLockers)
        {
            parcelLocker.Lockers.Should().NotBeNullOrEmpty();
            foreach (var locker in parcelLocker.Lockers)
            {
                locker.Should().NotBeNull();
                locker.ParcelLockerId.Should().NotBeEmpty();
            }
        }

        coordinates.Should().NotBeNullOrEmpty();
        coordinates.Should().HaveCount(allMockedCoordinates.Count);
        coordinates.Should().BeEquivalentTo(allMockedCoordinates);

        lockers.Should().NotBeNullOrEmpty();
        lockers.Should().HaveCount(parcelLockersQuantity * lockersPerParcelLocker);
        lockers.Should().BeEquivalentTo(allMockedLockers);
    }

    [Fact]
    public async Task SeedCustomParcelLocker_AddsNewParcelLockerToDatabase()
    {
        // Arrange
        var repository = new SqlEmptyParcelLockerRepository(_context);
        
        var parcelLockersQuantity = 5;
        var lockersPerParcelLocker = 3;
        var mockedParcelLockers = ParcelLockerMockData.GetParcelLockers(parcelLockersQuantity, lockersPerParcelLocker);
        EmptyParcelLockerDbSeeder.SeedParcelLockers(repository, mockedParcelLockers);
        var customParcelLocker = new ParcelLocker
        {
            Id = Guid.Parse("22e88beb-98bb-4922-adba-538e86f5834b"),
            Name = "CSZ08M",
            Address = "Frysztacka;61;;43-400;Cieszyn",
            Coordinates = new Coordinates
            {
                Id = Guid.NewGuid(),
                X = 49.75750794284093, 
                Y = 18.62290616610615,
            },
            Lockers = LockerMockData.GetLockers(30),
        };
        
        // Act
        EmptyParcelLockerDbSeeder.SeedCustomParcelLocker(repository, customParcelLocker);
        var parcelLockers = repository.GetParcelLockersAsync().Result;
        var parcelLocker = repository.GetParcelLockerAsync(customParcelLocker.Id).Result;

        // Assert
        parcelLocker.Should().BeEquivalentTo(customParcelLocker);
        parcelLockers.Should().HaveCount(parcelLockersQuantity + 1);
    }
}