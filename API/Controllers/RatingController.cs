using ASP.NET_aplikacija.BL.Services;
using ASP.NET_aplikacija.DL.DTO;
using Microsoft.AspNetCore.Mvc;


namespace ASP.NET_aplikacija.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _service;

        public RatingController(IRatingService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<RatingDTO> GetRatings(string coconut)
        {
            return _service.GetRatings(coconut);
        }
    }
}