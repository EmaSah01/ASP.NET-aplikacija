
namespace ASP.NET_aplikacija.Services
{
    public class AccountService : IAccountService
    {
        public async Task<string> GetAccountData(string accountId)
        {
            await Task.Delay(500); // simulacija poziva eksternog API-ja
            return $"Podaci za account {accountId}";
        }
    }
}

