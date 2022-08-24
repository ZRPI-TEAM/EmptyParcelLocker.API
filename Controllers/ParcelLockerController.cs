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
        return Ok(await _emptyParcelLockerService.GetParcelLockersAsync());
    }

    [HttpGet("{parcelLockerId:guid}")]
    public async Task<IActionResult> GetParcelLockerAsync(Guid parcelLockerId)
    {
        return Ok(await _emptyParcelLockerService.GetParcelLockerAsync(parcelLockerId));
    }

    [HttpPut("{parcelLocker}")]
    public async Task<IActionResult> UpdateParcelLocker(ParcelLocker parcelLocker)
    {
        try
        {
            await _emptyParcelLockerService.UpdateParcelLockerAsync(parcelLocker);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }
}