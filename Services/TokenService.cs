using ASP.NET_aplikacija.Configuration;
using Microsoft.Extensions.Options;

namespace ASP.NET_aplikacija.Services
{
    public interface ITokenService
    {
        Task<string> GetAccessToken();
    }
    public class TokenService : ITokenService
    {
        private readonly OAuthSettings _settings;

        public TokenService(IOptions<OAuthSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<string> GetAccessToken()
        {
            // DEV ONLY: vraća fiksni token
            await Task.Delay(50); // simulira async poziv
            return "dummy-access-token";
        }
    }
}