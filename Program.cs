using IncidentSimulator.Data;
using IncidentSimulator.Models;
using Microsoft.EntityFrameworkCore;
using IncidentSimulator.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

var app = builder.Build();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// 🔥 Seed initial services
DataStore.Services.Add(new ServiceModel { Id = 1, Name = "Auth Service", Status = "UP", LastChecked = DateTime.Now });
DataStore.Services.Add(new ServiceModel { Id = 2, Name = "Payment Service", Status = "UP", LastChecked = DateTime.Now });
DataStore.Services.Add(new ServiceModel { Id = 3, Name = "Database Service", Status = "UP", LastChecked = DateTime.Now });

app.Run();