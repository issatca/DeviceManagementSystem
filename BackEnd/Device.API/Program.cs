using Device.API.DbStorage;
using Device.API.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization; //*

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbFolder = Path.Combine(builder.Environment.ContentRootPath, "..");
var connectionString = "Server=localhost\\SQLEXPRESS;Database=DeviceManagement;Trusted_Connection=True;TrustServerCertificate=True;";

//so that the API won't use the enum underlying integer value
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddDbContext<DeviceManagementContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<DeviceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}