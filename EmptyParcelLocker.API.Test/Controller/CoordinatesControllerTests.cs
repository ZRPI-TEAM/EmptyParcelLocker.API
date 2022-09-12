using EmptyParcelLocker.API.Controllers;
using EmptyParcelLocker.API.Data.Models;
using EmptyParcelLocker.API.MockData;
using EmptyParcelLocker.API.Services.Coordinates;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmptyParcelLocker.API.Test.Controller;

public class CoordinatesControllerTests
{
    [Fact]
    public async Task GetAllCoordinates_ShouldReturnNoContent()
    {
        // Arrange
        var mockedCoordinatesService = new Mock<ICoordinatesService>();
        mockedCoordinatesService.Setup(_ => _.GetAllCoordinatesAsync()).ReturnsAsync(CoordinatesMockData.GetEmptyCoordinatesList);
        var sur = new CoordinatesController(mockedCoordinatesService.Object);
        
        // Act
        var result = (NoContentResult) await sur.GetAllCoordinatesAsync();

        // Assert
        result.StatusCode.Should().Be(204);
    }

    [Fact]
    public async Task GetAllCoordinates_ShouldReturnStatus200()
    {
        // Arrange
        var mockedCoordinatesService = new Mock<ICoordinatesService>();
        mockedCoordinatesService.Setup(_ => _.GetAllCoordinatesAsync()).ReturnsAsync(CoordinatesMockData.GetAllCoordinates);
        var sur = new CoordinatesController(mockedCoordinatesService.Object);
        
        // Act
        var result = (OkObjectResult) await sur.GetAllCoordinatesAsync();

        // Assert
        result.StatusCode.Should().Be(200);
    }
}