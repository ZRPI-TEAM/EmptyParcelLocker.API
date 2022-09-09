using EmptyParcelLocker.API.Data;
using EmptyParcelLocker.API.Mocker.MockData;
using EmptyParcelLocker.API.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace EmptyParcelLocker.API.Test.Repositories;

public class EmptyParcelLockerRepositoryTests : IDisposable
{
    protected readonly EmptyParcelLockerDbContext _context;

    public EmptyParcelLockerRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<EmptyParcelLockerDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString
            ()).Options;

        _context = new EmptyParcelLockerDbContext(options, false);

        _context.Database.EnsureCreated();
    }

    [Fact]
    public async Task GetLockerTypes_ReturnsLockerTypesCollection()
    {
        // Arrange
        await _context.LockerTypes.AddRangeAsync(LockerTypeMockData.GetLockerTypes());
        await _context.SaveChangesAsync();

        var systemUnderTest = new SqlEmptyParcelLockerRepository(_context);

        // Act
        var result = await systemUnderTest.GetLockerTypesAsync();

        // Assert
        result.Should().HaveCount(LockerTypeMockData.GetLockerTypes().Count);
    }

    [Fact]
    public async Task GetLockersAsync_ReturnsLockersCollection()
    {
        // Arrange
        var lockersQuantity = 4;
        await _context.Lockers.AddRangeAsync(LockerMockData.GetLockers(lockersQuantity));
        await _context.SaveChangesAsync();

        var systemUnderTest = new SqlEmptyParcelLockerRepository(_context);

        // Act
        var result = await systemUnderTest.GetLockersAsync();

        // Assert
        result.Should().HaveCount(lockersQuantity);
    }

    [Fact]
    public async Task GetParcelLockersAsync_ReturnsParcelLockersCollection()
    {
        // Arrange
        var parcelLockersQuantity = 3;
        var lockersQuantityPerParcelLocker = 5;
        var mockedParcelLockers = ParcelLockerMockData.GetParcelLockers(parcelLockersQuantity,
            lockersQuantityPerParcelLocker);
        
        await _context.ParcelLockers.AddRangeAsync(mockedParcelLockers);
        foreach (var mockedParcelLocker in mockedParcelLockers)
        {
            await _context.Lockers.AddRangeAsync(mockedParcelLocker.Lockers);
        }
        
        await _context.SaveChangesAsync();

        var systemUnderTest = new SqlEmptyParcelLockerRepository(_context);

        // Act
        var parcelLockers = await systemUnderTest.GetParcelLockersAsync();
        var lockers = await systemUnderTest.GetLockersAsync();

        // Assert
        parcelLockers.Should().HaveCount(parcelLockersQuantity);
        lockers.Should().HaveCount(parcelLockersQuantity * lockersQuantityPerParcelLocker);
    }

    [Fact]
    public async Task GetParcelLockerAsync_ReturnsParcelLocker()
    {
        // Assign
        var lockersQuantity = 5;
        var mockedParcelLocker = ParcelLockerMockData.GetParcelLocker(lockersQuantity);
        await _context.ParcelLockers.AddAsync(mockedParcelLocker);
        await _context.SaveChangesAsync();

        var systemUnderTest = new SqlEmptyParcelLockerRepository(_context);

        // Act
        var parcelLocker = await systemUnderTest.GetParcelLockerAsync(mockedParcelLocker.Id);
        var lockers = await systemUnderTest.GetLockersAsync();

        // Assert
        parcelLocker.Should().BeEquivalentTo(mockedParcelLocker);
        lockers.Should().HaveCount(lockersQuantity);
    }

    [Fact]
    public async Task GetLockerAsync_ReturnsLocker()
    {
        // Arrange
        var mockedLocker = LockerMockData.GetLocker();
        await _context.Lockers.AddAsync(mockedLocker);
        await _context.SaveChangesAsync();

        var systemUnderTest = new SqlEmptyParcelLockerRepository(_context);

        // Act
        var locker = await systemUnderTest.GetLockerAsync(mockedLocker.Id);
        
        // Assert
        locker.Should().BeEquivalentTo(mockedLocker);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}