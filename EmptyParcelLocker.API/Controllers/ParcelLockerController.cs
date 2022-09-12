using EmptyParcelLocker.API.Data.Models;
using EmptyParcelLocker.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ParcelLockerController : Controller
{
    private readonly IEmptyParcelLockerService _emptyParcelLockerService;

    public ParcelLockerController(IEmptyParcelLockerService emptyParcelLockerService)
    {
        _emptyParcelLockerService = emptyParcelLockerService;
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetParcelLockersAsync()
    {
        var parcelLockers = await _emptyParcelLockerService.GetParcelLockersAsync();
        if (parcelLockers.Count < 1)
        {
            return NoContent();
        }

        return Ok(parcelLockers);
    }

    [HttpGet("{parcelLockerId:guid}")]
    public async Task<IActionResult> GetParcelLockerAsync(Guid parcelLockerId)
    {
        var parcelLocker = await _emptyParcelLockerService.GetParcelLockerAsync(parcelLockerId);
        if (parcelLocker == null)
        {
            return NotFound();
        }

        return Ok(parcelLocker);
    }

    [HttpPut("{parcelLocker:guid}")]
    public async Task<IActionResult> UpdateParcelLocker(ParcelLocker parcelLocker)
    {
        return Ok(await _emptyParcelLockerService.UpdateParcelLockerAsync(parcelLocker));
    }

    [HttpGet]
    [Route("Coordinates/{parcelLockerId:guid}")]
    public async Task<IActionResult> GetParcelLockerCoordinatesAsync([FromRoute] Guid parcelLockerId)
    {
        return Ok(await _emptyParcelLockerService.GetParcelLockerCoordinatesAsync(parcelLockerId));
    }
}