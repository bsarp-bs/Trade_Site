using MediatR;
using Trade_Site_Demand_Application.Feature.CQRS.Handlers.AdressHandlers;
using Trade_Site_Demand_Application.Feature.CQRS.Handlers.OrderDetailHandlers;
using Trade_Site_Demand_Application.Feature.Mediator.Handlers.OrderMainHandlers;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Infrastructure_Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Trade_Site_Infrastructure_Persistence.Context;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<CreateOrderAdressCommandHandler>();
builder.Services.AddScoped<DeleteOrderAdressCommandHandler>();
builder.Services.AddScoped<UpdateOrderAdressCommandHandler>();
builder.Services.AddScoped<GetOrderAdressQueryHandler>();
builder.Services.AddScoped<GetOrderAdressByIdQueryHandler>();

builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<DeleteOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();

builder.Services.AddScoped(typeof(IGenericInterface<>), typeof(GenericRepository<>));

builder.Services.AddMediatR(typeof(CreateOrderMainCommandHandler).Assembly);

builder.Services.AddDbContext<DemandContext>();

// Add services to the container.

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TradeSite API ONION WITH CQRS");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
