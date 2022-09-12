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
}