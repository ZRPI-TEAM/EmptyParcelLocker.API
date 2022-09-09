using EmptyParcelLocker.API.Data;
using EmptyParcelLocker.API.ExtensionMethods;
using EmptyParcelLocker.API.Repositories;
using EmptyParcelLocker.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EmptyParcelLockerDbContext>();
builder.Services.AddScoped<IEmptyParcelLockerRepository, SqlEmptyParcelLockerRepository>();
builder.Services.AddScoped<IEmptyParcelLockerService, EmptyParcelLockerService>();
builder.Services.AddScoped<EmptyParcelLockerDbSeeder>();

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
