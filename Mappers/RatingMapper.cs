using ASP.NET_aplikacija.DTO;
using ASP.NET_aplikacija.Entities;

namespace ASP.NET_aplikacija.Mappers
{
    public class RatingMapper
    {
        public RatingEntity ToEntity(RatingDTO dto)
        {
            return new RatingEntity
            {
                Product = dto.Product,
                Score = dto.Score
            };
        }

        public RatingDTO ToDTO(RatingEntity entity)
        {
            return new RatingDTO
            {
                Product = entity.Product,
                Score = entity.Score
            };
        }
    }
}