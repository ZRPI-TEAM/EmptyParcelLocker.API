using System.Collections.ObjectModel;
using EmptyParcelLocker.API.Data;
using EmptyParcelLocker.API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmptyParcelLocker.API.Repositories;

public class SqlEmptyParcelLockerRepository : IEmptyParcelLockerRepository
{
    private readonly EmptyParcelLockerDbContext _context;

    public SqlEmptyParcelLockerRepository(EmptyParcelLockerDbContext context)
    {
        _context = context;
    }
}