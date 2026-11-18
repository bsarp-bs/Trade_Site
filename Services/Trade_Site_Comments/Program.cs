using Trade_Site_Comments.DTOs.MappingFile;
using Microsoft.EntityFrameworkCore;
using Trade_Site_Comments.Context;
using Trade_Site_Comments.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Db_Context>();
builder.Services.AddAutoMapper(typeof(_MapperFile));
builder.Services.AddScoped<ICommentService, CommentService>();
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
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TradeSite API Comments");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

