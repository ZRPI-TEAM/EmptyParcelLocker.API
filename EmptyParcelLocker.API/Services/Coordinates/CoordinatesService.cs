using EmptyParcelLocker.API.CustomExceptions;
using EmptyParcelLocker.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Services.Coordinates;

public class CoordinatesService : ICoordinatesService
{
    private readonly IEmptyParcelLockerRepository _repository;

    public CoordinatesService(IEmptyParcelLockerRepository repository)
    {
        _repository = repository;
    }

    /// <returns>Coordinates database table content</returns>
    /// <exception cref="NoContentException">Handle situation when coordinates list was null or empty</exception>
    public async Task<List<Data.Models.Coordinates>> GetAllCoordinatesAsync()
    {
        var coordinates = await _repository.GetAllCoordinatesAsync();
        if (coordinates == null || coordinates.Count < 1)
        {
            throw new NoContentException(nameof(List<Data.Models.Coordinates>));
        }

        return coordinates;
    }
}