using Flights.Application.Configuration;
using Flights.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterInfrastructure();
builder.Services.RegisterServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();