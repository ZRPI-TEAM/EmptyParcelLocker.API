using System.Net;
using EmptyParcelLocker.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoordinatesController : Controller
    {
        private readonly IEmptyParcelLockerService _emptyParcelLockerService;
        public CoordinatesController(IEmptyParcelLockerService emptyParcelLockerService)
        {
            _emptyParcelLockerService = emptyParcelLockerService;
        }
        
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllCoordinates()
        {
            var coordinates = await _emptyParcelLockerService.GetCoordinatesAsync();
            if (coordinates.Count < 1)
            {
                return NoContent();
            }

            return Ok(coordinates);
        }

        [HttpGet]
        [Route("{coordinatesId: guid}")]
        public async Task<IActionResult> GetParcelLockerByCoordinates([FromRoute] Guid coordinatesId)
        {
            var parcelLocker = await _emptyParcelLockerService.GetParcelLockerByCoordinatesAsync(coordinatesId);

            if (parcelLocker == null)
            {
                return NoContent();
            }

            return Ok(parcelLocker);
        }
    }
}