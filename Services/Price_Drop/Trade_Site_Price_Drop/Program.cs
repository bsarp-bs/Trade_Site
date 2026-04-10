using Microsoft.EntityFrameworkCore;
using Trade_Site_Price_Drop.Context;
using Trade_Site_Price_Drop.Service.DiscountServiceFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PriceDropContextFactory>();
builder.Services.AddScoped<IDiscountService, DiscountService>();

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
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TradeSite API Dapper");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
