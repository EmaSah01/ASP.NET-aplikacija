using ASP.NET_aplikacija.Configuration;
using ASP.NET_aplikacija.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure settings from appsettings.json
builder.Services.Configure<OAuthSettings>(
    builder.Configuration.GetSection("OAuth"));
builder.Services.Configure<ExternalApiSettings>(
    builder.Configuration.GetSection("ExternalApi"));

// ---- Registracija servisa ----

// Dummy TokenService ne treba HttpClient
builder.Services.AddScoped<ITokenService, TokenService>();

// ExternalApiService i AccountService
builder.Services.AddScoped<IExternalApiService, ExternalApiService>();
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