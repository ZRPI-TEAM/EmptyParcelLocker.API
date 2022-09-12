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
    }
}