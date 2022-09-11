using EmptyParcelLocker.API.Data;
using EmptyParcelLocker.API.Repositories;
using EmptyParcelLocker.API.Services;

namespace EmptyParcelLocker.API.ExtensionMethods;

public static class WebApplicationExtensionMethods
{
    public static void SeedDatabase(this WebApplication app)
    {
        using var scopes = app.Services.CreateScope();
        var emptyParcelLockerRepository = scopes.ServiceProvider.GetRequiredService<IEmptyParcelLockerRepository>();
        EmptyParcelLockerDbSeeder.SeedDatabase(emptyParcelLockerRepository);
    }
}