using EmptyParcelLocker.API.CustomExceptions;
using EmptyParcelLocker.API.Domain;
using EmptyParcelLocker.API.Services.ParcelLocker;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ParcelLockerController : Controller
{
    private readonly IParcelLockerService _parcelLockerService;

    public ParcelLockerController(IParcelLockerService parcelLockerService)
    {
        _parcelLockerService = parcelLockerService;
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllParcelLockersAsync()
    {
        try
        {
            var parcelLockers = await _parcelLockerService.GetAllParcelLockersAsync();
            var mappedParcelLockers = await Mapper.MapParcelLockerList(parcelLockers, _parcelLockerService);
            return Ok(mappedParcelLockers);
        }
        catch (NoContentException e)
        {
            Console.WriteLine(e.Message);
            return NoContent();
        }
    }
}