using ASP.NET_aplikacija.BL.Services;
using ASP.NET_aplikacija.DL.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASP.NET_aplikacija.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _service;
        private readonly ILogger<RatingController> _logger;

        public RatingController(IRatingService service, ILogger<RatingController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET api/rating?coconut
        [HttpGet]
        public ActionResult<List<RatingDTO>> GetRatings(string coconut)
        {
            _logger.LogInformation("GetRatings called with coconut={Coconut}", coconut);

            try
            {
                var ratings = _service.GetRatings(coconut);

                _logger.LogInformation("Returned {Count} ratings for coconut={Coconut}", ratings.Count, coconut);

                return Ok(ratings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting ratings for coconut={Coconut}", coconut);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}

// trebali bi integrisati logovi koji zapisuju  u fajl 
// dva kontrollera 
// prvi je okej
// prima listu coconuta vracati listu listi,  lista koja ima objekat u sebi.