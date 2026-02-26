using ASP.NET_aplikacija.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_aplikacija.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IAccountService _service;

        public RatingController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet("list-of-ratings")]
        public async Task<IActionResult> GetRatings()
        {
            var tasks = new List<Task<string>>();

            for (int i = 1; i <= 50; i++)
            {
                tasks.Add(_service.GetAccountData(i.ToString()));
            }

            var results = await Task.WhenAll(tasks);

            return Ok(results);
        }
    }
}
