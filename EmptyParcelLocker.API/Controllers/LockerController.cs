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
}