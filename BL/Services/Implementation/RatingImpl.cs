using ASP.NET_aplikacija.BL.Services;
using ASP.NET_aplikacija.DL.DAO;
using ASP.NET_aplikacija.DL.DTO;
using ASP.NET_aplikacija.DL.Entities;
using ASP.NET_aplikacija.DL.Mappers;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ASP.NET_aplikacija.BL.Services.Implementation
{
    public class RatingImpl : IRatingService
    {
        private readonly RatingDAO _dao;
        private readonly RatingMapper _mapper;
        private readonly ILogger<RatingImpl> _logger;

        public RatingImpl(RatingDAO dao, RatingMapper mapper, ILogger<RatingImpl> logger)
        {
            _dao = dao;
            _mapper = mapper;
            _logger = logger;
        }

        // GetRatings 
        public List<RatingDTO> GetRatings(string coconut)
        {
            _logger.LogInformation("GetRatings called for product {Product}", coconut);

            // simulacija eksternog poziva / dohvat podataka
            List<RatingDTO> ratings = new List<RatingDTO>()
            {
                new RatingDTO { Product = coconut, Score = 5 },
                new RatingDTO { Product = coconut, Score = 4 }
            };

            // konverzija DTO → Entity
            var entities = _mapper.ToEntities(ratings);

            // spremanje u bazu
            _dao.SaveRatings(entities);

            _logger.LogInformation("Saved {Count} ratings for product {Product}", ratings.Count, coconut);

            return ratings;
        }

        // Bulk metoda za više proizvoda
        public List<List<RatingDTO>> GetRatingsForProducts(List<string> products)
        {
            _logger.LogInformation("GetRatingsForProducts called for {Count} products", products.Count);

            var result = new List<List<RatingDTO>>();

            foreach (var product in products)
            {
                var ratings = GetRatings(product);
                result.Add(ratings);
            }

            _logger.LogInformation("Returned ratings for {Count} products", result.Count);

            return result;
        }

        // SaveDeviceRating 
        public void SaveDeviceRating(RatingDTO dto)
        {
            _logger.LogInformation("SaveDeviceRating called for product {Product} with score {Score}", dto.Product, dto.Score);

            var entity = _mapper.ToEntity(dto);
            _dao.SaveRatings(new List<RatingEntity> { entity });

            _logger.LogInformation("Saved rating successfully for product {Product}", dto.Product);
        }
    }
}

// anotacija ya transakciju u dontnetu
// ili sve da prodje ili nikako
// da se ubace logovi na nivou liste ili svakog ratinga
// exceptions try catch
// konekcija na bazu
