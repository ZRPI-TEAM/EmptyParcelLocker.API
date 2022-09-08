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

    [HttpPut()]
    [Route("{lockerid:guid}}")]
    public async Task<IActionResult> UpdateLockerEmptyStatusAsync([FromRoute] Guid lockerId, [FromBody] bool isEmpty)
    {
        return await _emptyParcelLockerService.UpdateLockerEmptyStatusAsync(lockerId, isEmpty) switch
        {
            NotFoundResult => NotFound(),
            OkResult => Ok(),
            _ => BadRequest(),
        };
    }
}