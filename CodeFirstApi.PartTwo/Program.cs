
using CodeFirstApi.PartTwo.Data;
using CodeFirstApi.PartTwo.Data.Model;
using CodeFirstApi.PartTwo.Interface;
using CodeFirstApi.PartTwo.Model;
using CodeFirstApi.PartTwo.Repository.Interface;
using CodeFirstApi.PartTwo.Repository.Repository;
using CodeFirstApi.PartTwo.Service.Interface;
using CodeFirstApi.PartTwo.Service.Repository;
using CodeFirstApi.PartTwo.Service.ValidationModel;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddTransient<ICarRepository, CarRepository>();
builder.Services.AddTransient<IEngineRepository, EngineRepository>();
builder.Services.AddTransient<IEngineTypeRepository, EngineTypeRepository>();

builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<IEngineService, EngineService>();
builder.Services.AddTransient<IEngineTypeService, EngineTypeService>();


builder.Services.AddTransient<IValidator<Car>, CarValidator>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CarConnectionString"));
});
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
