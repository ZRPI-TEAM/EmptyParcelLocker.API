using EmptyParcelLocker.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmptyParcelLocker.API.Data;

public class EmptyParcelLockerDbContext : DbContext
{
    public EmptyParcelLockerDbContext(DbContextOptions<EmptyParcelLockerDbContext> options) : base(options)
    { }

    public DbSet<ParcelLocker> ParcelLockers { get; set; }
    public DbSet<Locker> Lockers { get; set; }
    public DbSet<LockerType> LockerTypes { get; set; }
    public DbSet<Coordinates> Coordinates { get; set; }
    public DbSet<Address> Addresses { get; set; }
}