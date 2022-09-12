using System.Net;
using EmptyParcelLocker.API.CustomExceptions;
using EmptyParcelLocker.API.Data.Models;
using EmptyParcelLocker.API.Services;
using EmptyParcelLocker.API.Services.Coordinates;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Controllers
{
    [ApiController]
    public class CoordinatesController : Controller
    {
        private readonly ICoordinatesService _coordinatesService;
        public CoordinatesController(ICoordinatesService coordinatesService)
        {
            _coordinatesService = coordinatesService;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllCoordinatesAsync()
        {
            try
            {
                var coordinates = await _coordinatesService.GetAllCoordinatesAsync();
                return Ok(coordinates);
            }
            catch (NoContentException e)
            {
                Console.WriteLine(e.Message);
                return NoContent();
            }
        }
    }
}