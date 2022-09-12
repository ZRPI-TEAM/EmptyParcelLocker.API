using EmptyParcelLocker.API.Data;
using EmptyParcelLocker.API.MockData;
using EmptyParcelLocker.API.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace EmptyParcelLocker.API.Test.Repositories;

public class EmptyParcelLockerRepositoryTests : IDisposable
{
    protected readonly EmptyParcelLockerDbContext _context;

    public EmptyParcelLockerRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<EmptyParcelLockerDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString
            ()).Options;

        _context = new EmptyParcelLockerDbContext(options, false);

        _context.Database.EnsureCreated();
    }
    
    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}