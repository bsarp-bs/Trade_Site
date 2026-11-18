using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Trade_Site_Cargo_BusinessLayer.Managers;
using Trade_Site_Cargo_BusinessLayer.Services;
using Trade_Site_Cargo_DataAccessLayer.Abstract.Seperate;
using Trade_Site_Cargo_DataAccessLayer.Context;
using Trade_Site_Cargo_DataAccessLayer.EntityFramework.Separate;
using Trade_Site_Cargo_DtoLayer.DTOs.MapperConfig;
using Trade_Site_Cargo_WebAPI.CargoLoginService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// AutoMapper
builder.Services.AddAutoMapper(typeof(Mapper));

// Connection string comes from configuration (user-secrets / environment), never from code.
var cargoDb = builder.Configuration.GetConnectionString("CargoDb");
if (string.IsNullOrWhiteSpace(cargoDb))
{
    throw new InvalidOperationException(
        "ConnectionStrings:CargoDb is not configured. Set it with dotnet user-secrets or the ConnectionStrings__CargoDb environment variable (see README).");
}

builder.Services.AddDbContext<CargoContext>(options => options.UseSqlServer(cargoDb));


builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();
builder.Services.AddScoped<ICargoStatusService, CargoStatusManager>();
builder.Services.AddScoped<ICargoOwnerService, CargoOwnerManager>();
builder.Services.AddScoped<ICargoCabService, CargoCabManager>();

builder.Services.AddScoped<ICargoDetailDAL, EFCargoDetailDAL>();
builder.Services.AddScoped<ICargoStatusDAL, EFCargoStatusDAL>();
builder.Services.AddScoped<ICargoOwnerDAL, EFCargoOwnerDAL>();
builder.Services.AddScoped<ICargoCabDAL, EFCargoCabDAL>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ILoginService, LoginService>();

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var jwtKey = builder.Configuration["Jwt:Key"] ?? string.Empty;
if (Encoding.UTF8.GetByteCount(jwtKey) < 32)
{
    throw new InvalidOperationException(
        "Jwt:Key must be set to at least 32 bytes and match the Auth service. Set it with dotnet user-secrets or the Jwt__Key environment variable (see README).");
}
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TradeSite API Cargo Docker");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
