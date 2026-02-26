using ASP.NET_aplikacija.Configuration;
using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace ASP.NET_aplikacija.Services
{

    public class TokenService : ITokenService
    {
        private readonly OAuthSettings _settings;
        private readonly HttpClient _httpClient;

        public TokenService(
            IOptions<OAuthSettings> settings,
            HttpClient httpClient)
        {
            _settings = settings.Value;
            _httpClient = httpClient;
        }

        public async Task<string> GetAccessToken()
        {
            var response = await _httpClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = _settings.TokenUrl,
                    ClientId = _settings.ClientId,
                    ClientSecret = _settings.ClientSecret,
                    Scope = _settings.Scope
                });

            if (response.IsError)
                throw new Exception(response.Error);

            return response.AccessToken;
        }
    }
}
