using EmptyParcelLocker.API.Services;
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
}