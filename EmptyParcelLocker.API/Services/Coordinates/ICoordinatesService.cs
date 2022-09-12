using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Services.Coordinates;

public interface ICoordinatesService
{
    Task<List<Data.Models.Coordinates>> GetAllCoordinatesAsync();
}