using ASP.NET_aplikacija.BL.Services;
using ASP.NET_aplikacija.DL.DAO;
using ASP.NET_aplikacija.DL.DTO;
using ASP.NET_aplikacija.DL.Entities;
using ASP.NET_aplikacija.DL.Mappers;

namespace ASP.NET_aplikacija.BL.Services.Implementation
{
    public class RatingImpl : IRatingService
    {
        private readonly RatingDAO _dao;
        private readonly RatingMapper _mapper;

        public RatingImpl(RatingDAO dao, RatingMapper mapper)
        {
            _dao = dao;
            _mapper = mapper;
        }

        public List<RatingDTO> GetRatings(string coconut)
        {
            // simulacija eksternog poziva
            List<RatingDTO> ratings = new List<RatingDTO>()
            {
                new RatingDTO { Product = coconut, Score = 5 },
                new RatingDTO { Product = coconut, Score = 4 }
            };

            List<RatingEntity> entities = new List<RatingEntity>();

            foreach (var dto in ratings)
            {
                entities.Add(_mapper.ToEntity(dto));
            }

            _dao.SaveRatings(entities);

            return ratings;
        }
    }
}