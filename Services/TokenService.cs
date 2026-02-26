using ASP.NET_aplikacija.Configuration;
using ASP.NET_aplikacija.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;

namespace ASP.NET_aplikacija.Services
{

    namespace ASP.NET_aplikacija.Services
    {
        public class TokenService : ITokenService
        {
            private readonly OAuthSettings _settings;

            public TokenService(IOptions<OAuthSettings> settings)
            {
                _settings = settings.Value;
            }

            public async Task<string> GetAccessToken()
            {
                // DEV ONLY: vraća dummy token
                await Task.Delay(50); // simulira async call
                return "dummy-access-token";
            }
        }
    }
}