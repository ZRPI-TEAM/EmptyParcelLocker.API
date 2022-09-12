using EmptyParcelLocker.API.Data.Models;
using EmptyParcelLocker.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ParcelLockerController : Controller
{
    private readonly IEmptyParcelLockerService _emptyParcelLockerService;

    public ParcelLockerController(IEmptyParcelLockerService emptyParcelLockerService)
    {
        _emptyParcelLockerService = emptyParcelLockerService;
    }
}