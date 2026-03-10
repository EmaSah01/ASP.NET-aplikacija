using ASP.NET_aplikacija.DL.DTO;
using ASP.NET_aplikacija.DL.Entities;

namespace ASP.NET_aplikacija.DL.Mappers
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


        //konverzija liste 
        public List<RatingEntity> ToEntities(List<RatingDTO> dtos)
        {
            return dtos.Select(d => ToEntity(d)).ToList();
        }

        public List<RatingDTO> ToDTOs(List<RatingEntity> entities)
        {
            return entities.Select(e => ToDTO(e)).ToList();
        }
    }
}