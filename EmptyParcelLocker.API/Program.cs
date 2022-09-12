using EmptyParcelLocker.API.Data;
using EmptyParcelLocker.API.ExtensionMethods;
using EmptyParcelLocker.API.Repositories;
using EmptyParcelLocker.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddScoped<IEmptyParcelLockerRepository, SqlEmptyParcelLockerRepository>();

// TODO: AddScoped services

builder.Services.AddDbContext<EmptyParcelLockerDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("ParcelLockerDb")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.SeedDatabase();

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
