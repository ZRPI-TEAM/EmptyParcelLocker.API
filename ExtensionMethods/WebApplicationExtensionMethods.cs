using EmptyParcelLocker.API.Data;
using EmptyParcelLocker.API.Services;

namespace EmptyParcelLocker.API.ExtensionMethods;

public static class WebApplicationExtensionMethods
{
    public static void SeedDatabase(this WebApplication app)
    {
        var service = app.Services.GetService(typeof(EmptyParcelLockerService)) as EmptyParcelLockerService;
        var emptyParcelLockerDbSeeder = new EmptyParcelLockerDbSeeder(service);
        emptyParcelLockerDbSeeder.SeedAsync().Wait();
    }
}