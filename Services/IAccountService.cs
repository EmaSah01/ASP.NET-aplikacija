namespace ASP.NET_aplikacija.Services
{
    public interface IAccountService
    {
        Task<string> GetAccountData(string accountId);
    }
}
