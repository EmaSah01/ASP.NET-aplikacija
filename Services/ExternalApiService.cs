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

            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"accounts/{accountId}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
