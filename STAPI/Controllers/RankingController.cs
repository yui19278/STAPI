using Microsoft.AspNetCore.Mvc;
using STAPI.Services;

namespace STAPI.Controllers
{
    [ApiController]
    [Route("api/ranking")]
    public class RankingController : ControllerBase
    {
        private readonly RankingService _rankingService;

        public RankingController(RankingService rankingService)
        {
            _rankingService = rankingService;
        }

        [HttpGet]
        public IActionResult GetRankings()
        {
            var rankings = _rankingService.GetRankings();
            return Ok(rankings);
        }
    }
}
