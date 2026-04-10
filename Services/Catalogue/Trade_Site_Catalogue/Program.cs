using AutoMapper;
using Microsoft.Extensions.Options;
using System.Reflection;
using Trade_Site_Catalogue.DTOs.Mapper;
using Trade_Site_Catalogue.Services.CategoryServiceFiles;
using Trade_Site_Catalogue.Services.ProductInfoServiceFiles;
using Trade_Site_Catalogue.Services.ProductPhotoServiceFiles;
using Trade_Site_Catalogue.Services.ProductServiceFiles;
using Trade_Site_Catalogue.Settings;

var builder = WebApplication.CreateBuilder(args);

// Services - DAL

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductInfoService, ProductInfoService>();
builder.Services.AddScoped<IProductPhotoService, ProductPhotoService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection(nameof(DatabaseSettings)));

builder.Services.AddScoped<IDatabaseSettings>(sp =>
   {
       return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
   });

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TradeSite API MongoDB");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
