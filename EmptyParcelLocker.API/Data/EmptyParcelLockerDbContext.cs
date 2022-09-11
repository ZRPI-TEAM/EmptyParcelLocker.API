using EmptyParcelLocker.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmptyParcelLocker.API.Data;

public class EmptyParcelLockerDbContext : DbContext
{
    private IConfiguration _configuration;
    private readonly bool _selectDbOnConfiguring = true;

    public EmptyParcelLockerDbContext(DbContextOptions<EmptyParcelLockerDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public EmptyParcelLockerDbContext(DbContextOptions<EmptyParcelLockerDbContext> options, bool selectDbOnConfiguring) : base(options)
    {
        _selectDbOnConfiguring = selectDbOnConfiguring;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (_selectDbOnConfiguring)
        {
            options.UseSqlServer(_configuration.GetConnectionString("ParcelLockerDb"));
        }
    }

    public DbSet<ParcelLocker> ParcelLockers { get; set; }
    public DbSet<Locker> Lockers { get; set; }
    public DbSet<LockerType> LockerTypes { get; set; }

    public DbSet<Coordinates> Coordinates { get; set; }
}