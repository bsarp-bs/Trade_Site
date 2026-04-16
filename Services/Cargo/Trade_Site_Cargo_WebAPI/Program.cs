using Microsoft.EntityFrameworkCore;
using Trade_Site_Cargo_BusinessLayer.Managers;
using Trade_Site_Cargo_BusinessLayer.Services;
using Trade_Site_Cargo_DataAccessLayer.Abstract.Seperate;
using Trade_Site_Cargo_DataAccessLayer.Context;
using Trade_Site_Cargo_DataAccessLayer.EntityFramework.Separate;
using Trade_Site_Cargo_DtoLayer.DTOs.MapperConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// AutoMapper
builder.Services.AddAutoMapper(typeof(Mapper));

builder.Services.AddDbContext<CargoContext>();

builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();
builder.Services.AddScoped<ICargoStatusService, CargoStatusManager>();
builder.Services.AddScoped<ICargoOwnerService, CargoOwnerManager>();
builder.Services.AddScoped<ICargoCabService, CargoCabManager>();

builder.Services.AddScoped<ICargoDetailDAL, EFCargoDetailDAL>();
builder.Services.AddScoped<ICargoStatusDAL, EFCargoStatusDAL>();
builder.Services.AddScoped<ICargoOwnerDAL, EFCargoOwnerDAL>();
builder.Services.AddScoped<ICargoCabDAL, EFCargoCabDAL>();

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TradeSite API Cargo Docker");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
