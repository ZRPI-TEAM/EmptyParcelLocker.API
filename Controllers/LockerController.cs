using EmptyParcelLocker.API.Data.Models;
using EmptyParcelLocker.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LockerController : Controller
{
    private readonly IEmptyParcelLockerService _emptyParcelLockerService;

    public LockerController(IEmptyParcelLockerService emptyParcelLockerService)
    {
        _emptyParcelLockerService = emptyParcelLockerService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetLockersAsync()
    {
        return Ok(await _emptyParcelLockerService.GetLockersAsync());
    }

    [HttpGet("{lockerId:guid}")]
    public async Task<IActionResult> GetLockerAsync(Guid lockerId)
    {
        return Ok(await _emptyParcelLockerService.GetLockerAsync(lockerId));
    }

    [HttpPut("/{locker}")]
    public async Task<IActionResult> UpdateLocker(Locker locker)
    {
        try
        {
            await _emptyParcelLockerService.UpdateLockerAsync(locker);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }
}