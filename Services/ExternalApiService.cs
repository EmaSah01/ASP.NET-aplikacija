using ASP.NET_aplikacija.Configuration;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace ASP.NET_aplikacija.Services
{

    public class ExternalApiService : IExternalApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private readonly ExternalApiSettings _settings;

        public ExternalApiService(
            HttpClient httpClient,
            ITokenService tokenService,
            IOptions<ExternalApiSettings> settings)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
            _settings = settings.Value;
        }

        public async Task<string> GetAccountData(string accountId)
        {
            var token = await _tokenService.GetAccessToken();

            // Postavimo fiktivni odgovor za testiranje
            await Task.Delay(50); // simulacija poziva
            return $"{{\"accountId\":\"{accountId}\", \"balance\": 1000, \"tokenUsed\": \"{token}\"}}";
        }
    }
}