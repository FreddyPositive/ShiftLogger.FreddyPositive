using Microsoft.EntityFrameworkCore;
using ShiftLogger.DataAccess;
using ShiftLogger.Models;
using ShiftLogger.Service;
using ShiftLogger.Utils;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IShiftLoggerService, ShiftLoggerService>();
builder.Services.AddScoped<IShiftLoggerDataAccess, ShiftLoggerDataAcess>();
builder.Services.AddScoped<ServiceUtils>();
builder.Services.AddDbContext<ShiftLoggerDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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
