using ASP.NET_aplikacija.Configuration;
using ASP.NET_aplikacija.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<OAuthSettings>(
builder.Configuration.GetSection("OAuth"));

builder.Services.Configure<ExternalApiSettings>(
builder.Configuration.GetSection("ExternalApi"));



builder.Services.AddHttpClient<ITokenService, TokenService>();
builder.Services.AddHttpClient<IExternalApiService, ExternalApiService>();
builder.Services.AddScoped<IAccountService, AccountService>();
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
