using Microsoft.EntityFrameworkCore;
using StudentPortfolio.API.Infrastructure;
using StudentPortfolio.API.Models;
using StudentPortfolio.API.Repositories;
using StudentPortfolio.API.Repositories.Base;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAcknowledgementsRepository, AcknowledgementsRepository>();

var connectionString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContext<StudentPortfolioContext>(options =>
    options.UseSqlServer(connectionString));

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
