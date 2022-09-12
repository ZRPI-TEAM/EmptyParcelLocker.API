using EmptyParcelLocker.API.Data;
using EmptyParcelLocker.API.Data.Models;
using EmptyParcelLocker.API.MockData;
using EmptyParcelLocker.API.Repositories;
using EmptyParcelLocker.API.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace EmptyParcelLocker.API.Test.DataTests;

public class EmptyParcelLockerDbSeederTests
{
    protected readonly EmptyParcelLockerDbContext _context;

    public EmptyParcelLockerDbSeederTests()
    {
        var options = new DbContextOptionsBuilder<EmptyParcelLockerDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString
            ()).Options;

        _context = new EmptyParcelLockerDbContext(options, false);

        _context.Database.EnsureCreated();
    }
}