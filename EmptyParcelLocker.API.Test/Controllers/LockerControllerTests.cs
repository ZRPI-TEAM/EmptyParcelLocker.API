using EmptyParcelLocker.API.Controllers;
using EmptyParcelLocker.API.Data.Models;
using EmptyParcelLocker.API.Mocker.MockData;
using EmptyParcelLocker.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmptyParcelLocker.API.Test.Controllers;

public class LockerControllerTests
{
    [Fact]
    public async Task GetLockersAsync_ShouldReturn200Status()
    {
        // Arrange
        var emptyParcelLockerService = new Mock<IEmptyParcelLockerService>();
        emptyParcelLockerService.Setup(_ => _.GetLockersAsync()).ReturnsAsync(LockerMockData.GetLockers(10));
        var systemUnderTest = new LockerController(emptyParcelLockerService.Object);

        // Act
        var result = (OkObjectResult) await systemUnderTest.GetLockersAsync();

        // Assert
        result.StatusCode.Should().Be(200);
    }
    
    [Fact]
    async Task UpdateLockerEmptyStatusAsync_ShouldChangeLockerIsEmptyProperty()
    {
        // Arrange
        var mockedLocker = LockerMockData.GetLocker();
        var mockedLockerWithChangedEmptyStatus = new Locker
        {
            Id = mockedLocker.Id,
            IsEmpty = !mockedLocker.IsEmpty,
            LockerType = mockedLocker.LockerType,
            LockerTypeId = mockedLocker.LockerTypeId,
            ParcelLocerId = mockedLocker.ParcelLocerId,
        };

        var emptyParcelLockerService = new Mock<IEmptyParcelLockerService>();
        emptyParcelLockerService.Setup(_ => _.UpdateLockerEmptyStatusAsync(mockedLocker.Id, !mockedLocker.IsEmpty)).ReturnsAsync(new OkResult());
        emptyParcelLockerService.Setup(_ => _.GetLockerAsync(mockedLocker.Id)).ReturnsAsync(mockedLockerWithChangedEmptyStatus);

        var systemUnderTest = new EmptyParcelLockerService(emptyParcelLockerService.Object);

        // Act
        var result = (OkResult) await systemUnderTest.UpdateLockerEmptyStatusAsync(mockedLocker.Id, !mockedLocker.IsEmpty);
        var locker = await systemUnderTest.GetLockerAsync(mockedLocker.Id);
        // Assert
        result.StatusCode.Should().Be(200);
        locker.IsEmpty.Should().NotBe(mockedLocker.IsEmpty);
    }
}