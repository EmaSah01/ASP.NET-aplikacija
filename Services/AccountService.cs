
namespace ASP.NET_aplikacija.Services
{
    public class AccountService : IAccountService
    {
        private readonly IExternalApiService _externalApi;

        public AccountService(IExternalApiService externalApi)
        {
            _externalApi = externalApi;
        }

        public async Task<string> GetAccountData(string accountId)
        {
            return await _externalApi.GetAccountData(accountId);
        }
    }
}

