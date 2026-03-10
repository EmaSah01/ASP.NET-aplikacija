using ASP.NET_aplikacija.BL.Services;
using ASP.NET_aplikacija.DL.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ASP.NET_aplikacija.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IRatingService _service;
        private readonly ILogger<DeviceController> _logger;

        public DeviceController(IRatingService service, ILogger<DeviceController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // POST api/device/ratings
        [HttpPost("ratings")]
        public IActionResult ReceiveRatings([FromBody] List<RatingDTO> ratings)
        {
            if (ratings == null || ratings.Count == 0)
            {
                _logger.LogWarning("ReceiveRatings called with empty list");
                return BadRequest("Ratings list cannot be empty");
            }

            _logger.LogInformation("ReceiveRatings called with {Count} ratings", ratings.Count);

            // Spremi sve ratinge u bazu kroz servis
            foreach (var dto in ratings)
            {
                _logger.LogInformation("Saving rating: Product={Product}, Score={Score}", dto.Product, dto.Score);
                _service.SaveDeviceRating(dto); // Metoda u servisu koja sprema pojedinačni DTO
            }

            _logger.LogInformation("{Count} ratings saved successfully", ratings.Count);

            return Ok(new { message = $"{ratings.Count} ratings saved successfully" });
        }
    }
}