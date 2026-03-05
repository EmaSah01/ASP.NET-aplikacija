using ASP.NET_aplikacija.DTO;

namespace ASP.NET_aplikacija.Services
{
    public interface IRatingService
    {
        List<RatingDTO> GetRatings(string coconut);
    }
}
