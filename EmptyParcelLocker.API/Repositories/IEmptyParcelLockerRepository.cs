using EmptyParcelLocker.API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Repositories;

public interface IEmptyParcelLockerRepository
{
    Task<List<Coordinates>> GetAllCoordinatesAsync();
}