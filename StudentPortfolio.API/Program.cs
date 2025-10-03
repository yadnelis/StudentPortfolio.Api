using Mapster;
using Microsoft.EntityFrameworkCore;
using StudentPortfolio.API.Infrastructure;
using StudentPortfolio.API.Models;
using StudentPortfolio.API.Repositories;
using StudentPortfolio.API.Repositories.Base;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

TypeAdapterConfig.GlobalSettings.Default.IgnoreNullValues(true);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
builder.Services.AddScoped<IAcknowledgementsRepository, AcknowledgementsRepository>();

var connectionString = builder.Configuration.GetConnectionString("DbConnection");
var serverVersion = ServerVersion.AutoDetect(connectionString);

builder.Services.AddDbContext<StudentPortfolioContext>(sbContextoptions =>
    sbContextoptions
    .UseMySql(connectionString, serverVersion)
    .EnableDetailedErrors()
);

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

app.Map("/", () => "Ok");

app.Run();
