using EmptyParcelLocker.API.CustomExceptions;
using EmptyParcelLocker.API.MockData;
using EmptyParcelLocker.API.Repositories;
using EmptyParcelLocker.API.Services.Coordinates;
using FluentAssertions;
using Moq;

namespace EmptyParcelLocker.API.Test.Services;

public class CoordinatesServiceTests
{
    [Fact]
    public async Task GetAllCoordinates_ShouldHaveProperCount()
    {
        // Arrange
        var mockedRepository = new Mock<IEmptyParcelLockerRepository>();
        mockedRepository.Setup(_ => _.GetAllCoordinatesAsync()).ReturnsAsync(CoordinatesMockData.GetAllCoordinates);
        var sur = new CoordinatesService(mockedRepository.Object);
        
        // Act
        var result = await sur.GetAllCoordinatesAsync();
        
        // Assert
        result.Should().HaveCount(CoordinatesMockData.GetAllCoordinates().Count);
    }

    [Fact]
    public async Task GetAllCoordinates_ThrowsNoContentException()
    {
        var mockedRepository = new Mock<IEmptyParcelLockerRepository>();
        mockedRepository.Setup(_ => _.GetAllCoordinatesAsync()).ReturnsAsync(CoordinatesMockData.GetEmptyCoordinatesList);
        var sur = new CoordinatesService(mockedRepository.Object);

        await Assert.ThrowsAsync<NoContentException>(() => sur.GetAllCoordinatesAsync());
    }
}