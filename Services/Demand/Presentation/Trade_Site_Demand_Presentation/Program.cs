using MediatR;
using Trade_Site_Demand_Application.Feature.CQRS.Handlers.AdressHandlers;
using Trade_Site_Demand_Application.Feature.CQRS.Handlers.OrderDetailHandlers;
using Trade_Site_Demand_Application.Feature.Mediator.Handlers.OrderMainHandlers;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Infrastructure_Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Trade_Site_Infrastructure_Persistence.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


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

var jwtKey = builder.Configuration["Jwt:Key"] ?? string.Empty;
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
