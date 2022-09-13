using EmptyParcelLocker.API.Data;
using EmptyParcelLocker.API.Repositories;
using EmptyParcelLocker.API.Services.Locker;
using EmptyParcelLocker.API.Services.ParcelLocker;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddScoped<IEmptyParcelLockerRepository, SqlEmptyParcelLockerRepository>();

builder.Services.AddScoped<ILockerService, LockerService>();
builder.Services.AddScoped<IParcelLockerService, ParcelLockerService>();

builder.Services.AddDbContext<EmptyParcelLockerDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("ParcelLockerDb")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
