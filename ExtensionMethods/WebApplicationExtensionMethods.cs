using EmptyParcelLocker.API.Data;
using EmptyParcelLocker.API.Services;

namespace EmptyParcelLocker.API.ExtensionMethods;

public static class WebApplicationExtensionMethods
{
    public static void SeedDatabase(this WebApplication app)
    {
        using var scopes = app.Services.CreateScope();
        var emptyParcelLockerService = scopes.ServiceProvider.GetRequiredService<IEmptyParcelLockerService>();
        var emptyParcelLockerDbSeeder = new EmptyParcelLockerDbSeeder(emptyParcelLockerService);
        emptyParcelLockerDbSeeder.SeedAsync().Wait();
    }
}