using EmptyParcelLocker.API.Data.Models;
using EmptyParcelLocker.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmptyParcelLocker.API.Services;

public class EmptyParcelLockerService : IEmptyParcelLockerService
{
    private readonly IEmptyParcelLockerRepository _emptyParcelLockerRepository;

    public EmptyParcelLockerService(IEmptyParcelLockerRepository emptyParcelLockerRepository)
    {
        _emptyParcelLockerRepository = emptyParcelLockerRepository;
    }
}