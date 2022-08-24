using EmptyParcelLocker.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LockerTypeController : Controller
{
    private readonly IEmptyParcelLockerService _emptyParcelLockerService;

    public LockerTypeController(IEmptyParcelLockerService emptyParcelLockerService)
    {
        _emptyParcelLockerService = emptyParcelLockerService;
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetLockerTypesAsync()
    {
        return Ok(await _emptyParcelLockerService.GetLockerTypesAsync());
    }

    [HttpGet("{lockerTypeId:guid}")]
    public async Task<IActionResult> GetLockerTypeAsync(Guid lockerTypeId)
    {
        return Ok(await _emptyParcelLockerService.GetLockerTypeAsync(lockerTypeId));
    }
}