namespace ASP.NET_aplikacija.Services
{
    public interface IExternalApiService
    {
        Task<string> GetAccountData(string accountId);
    }
}
