using Microsoft.AspNetCore.Mvc;
using STAPI.Services;

namespace STAPI.Controllers
{
    [ApiController]
    [Route("api/market")]
    public class MarketController : ControllerBase
    {
        private readonly MarketService _marketService;

        public MarketController(MarketService marketService)
        {
            _marketService = marketService;
        }

        [HttpGet]
        public IActionResult GetMarketData()
        {
            var marketData = _marketService.GetMarketData();
            return Ok(marketData);
        }
    }
}
