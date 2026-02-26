namespace ASP.NET_aplikacija.Services
{
    public interface ITokenService
    {
        Task<string> GetAccessToken();
    }
}
