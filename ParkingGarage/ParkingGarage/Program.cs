using ParkingGarage;
using ParkingGarage.Configuration;
using ParkingGarage.Settings;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<SecuritySettings>(options => builder.Configuration.GetSection("security").Bind(options));

ParkingGarage.IStartup startup = new Startup();
startup.Configure(builder.Configuration, builder.Services);
startup.ConfigureServices(builder.Services, builder.Environment);

var app = builder.Build();

startup.ConfigureMiddleware(app, app.Environment);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
