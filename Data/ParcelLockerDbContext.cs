using EmptyParcelLocker.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmptyParcelLocker.API.Data;

public class ParcelLockerDbContext : DbContext
{
    private IConfiguration _configuration;

    public ParcelLockerDbContext(DbContextOptions<ParcelLockerDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("ParcelLockerDb"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParcelLocker>()
            .HasMany(p => p.Lockers)
            .WithOne(l => l.ParcelLocker)
            .IsRequired();

        modelBuilder.Entity<ParcelLockerAddress>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<ParcelLocker>()
            .HasOne<ParcelLockerAddress>(p => p.ParcelLockerAddress)
            .WithOne(a => a.ParcelLocker)
            .HasForeignKey<ParcelLockerAddress>(a => a.ParcelLockerId)
            .IsRequired();
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<ParcelLocker> ParcelLockers { get; set; }
    public DbSet<Locker> Lockers { get; set; }
    public DbSet<ParcelLockerAddress> Addresses { get; set; }
    public DbSet<LockerType> LockerTypes { get; set; }
}