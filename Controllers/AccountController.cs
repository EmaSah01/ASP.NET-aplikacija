using ASP.NET_aplikacija.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_aplikacija.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetAccount(string accountId)
        {
            var result = await _service.GetAccountData(accountId);
            return Ok(result);
        }
    }
}
