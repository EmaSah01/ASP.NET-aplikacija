using ASP.NET_aplikacija.DL.DTO;

namespace ASP.NET_aplikacija.BL.Services
{
    public interface IRatingService
    {
        List<RatingDTO> GetRatings(string coconut);
        void SaveDeviceRating(RatingDTO dto);
    }
}
