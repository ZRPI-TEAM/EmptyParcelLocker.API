using EmptyParcelLocker.API.Data.Models;
using EmptyParcelLocker.API.Services;
using EmptyParcelLocker.API.Services.ParcelLocker;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ParcelLockerController : Controller
{
    private readonly IParcelLockerService _parcelLockerService;

    public ParcelLockerController(IParcelLockerService parcelLockerService)
    {
        _parcelLockerService = parcelLockerService;
    }
}