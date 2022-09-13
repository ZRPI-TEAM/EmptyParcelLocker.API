using EmptyParcelLocker.API.CustomExceptions;
using EmptyParcelLocker.API.Domain;
using EmptyParcelLocker.API.Services.Locker;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LockerController : Controller
{
    private readonly ILockerService _lockerService;
    public LockerController(ILockerService lockerService)
    {
        _lockerService = lockerService;
    }

    [HttpGet]
    [Route("{parcelLockerId:guid}")]
    public async Task<IActionResult> GetLockersOfParcelLockerAsync([FromRoute] Guid parcelLockerId)
    {
        try
        {
            var lockers = await _lockerService.GetLockersOfParcelLockerAsync(parcelLockerId);
            var mappedLockers = await Mapper.MapLockerListAsync(lockers, _lockerService);
            return Ok(mappedLockers);
        }
        catch (NoContentException e)
        {
            Console.WriteLine(e.Message);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            Console.WriteLine(e.Message);
            return NotFound();
        }
    }

    [HttpPut]
    [Route("{lockerId:guid}")]
    public async Task<IActionResult> UpdateLockerEmptyStatusAsync([FromRoute] Guid lockerId, [FromBody] bool isEmpty)
    {
        try
        {
            var updatedLocker = await _lockerService.UpdateLockerEmptyStatusAsync(lockerId, isEmpty);
            var mappedUpdatedLocker = await Mapper.MapLockerAsync(updatedLocker, _lockerService);
            return Ok(mappedUpdatedLocker);
        }
        catch (NotFoundException e)
        {
            Console.WriteLine(e.Message);
            return NotFound();
        }
    }
}