using ASP.NET_aplikacija.Services;
using ASP.NET_aplikacija.Services.Implementation;
using ASP.NET_aplikacija.DAO;
using ASP.NET_aplikacija.Mappers;
using ASP.NET_aplikacija.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// DATABASE (može InMemory za testiranje)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("RatingsDB"));


// DEPENDENCY INJECTION

// Service
builder.Services.AddScoped<IRatingService, RatingImpl>();

// DAO
builder.Services.AddScoped<RatingDAO>();

// Mapper
builder.Services.AddScoped<RatingMapper>();


var app = builder.Build();


// HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();