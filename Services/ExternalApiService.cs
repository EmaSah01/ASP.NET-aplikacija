using ASP.NET_aplikacija.Configuration;

namespace ASP.NET_aplikacija.Services
{
    public class ExternalApiService : IExternalApiService
    {
        private readonly ITokenService _tokenService;

        public ExternalApiService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<string> GetAccountData(string accountId)
        {
            var token = await _tokenService.GetAccessToken();

            // DEV ONLY: simulirani odgovor, ne zove stvarni API
            await Task.Delay(50); // simulacija async poziva

            return $"{{\"accountId\":\"{accountId}\", \"balance\": 1000, \"tokenUsed\": \"{token}\"}}";
        }
    }
}