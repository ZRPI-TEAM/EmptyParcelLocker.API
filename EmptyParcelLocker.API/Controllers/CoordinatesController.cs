using System.Net;
using EmptyParcelLocker.API.Services;
using EmptyParcelLocker.API.Services.Coordinates;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoordinatesController : Controller
    {
        private readonly ICoordinatesService _coordinatesService;
        public CoordinatesController(ICoordinatesService coordinatesService)
        {
            _coordinatesService = coordinatesService;
        }
    }
}