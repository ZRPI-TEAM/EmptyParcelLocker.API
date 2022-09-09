using EmptyParcelLocker.API.Controllers;
using EmptyParcelLocker.API.Mocker.MockData;
using EmptyParcelLocker.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmptyParcelLocker.API.Test.Controllers;

public class ParcelLockerControllerTests
{
    [Fact]
    public async Task GetParcelLockersAsync_ShouldReturn200Status()
    {
        // Arrange
        var emptyParcelLockerService = new Mock<IEmptyParcelLockerService>();
        emptyParcelLockerService.Setup(_ => _.GetParcelLockersAsync()).ReturnsAsync(ParcelLockerMockData.GetParcelLockers(3,3));
        var systemUnderTest = new ParcelLockerController(emptyParcelLockerService.Object);

        // Act
        var result =  (OkObjectResult) await systemUnderTest.GetParcelLockersAsync();

        // Assert
        result.StatusCode.Should().Be(200);
    }
}