using Microsoft.AspNetCore.Mvc;
using STAPI.Services;
using STAPI.DTOs;
using System.Threading.Tasks;

namespace STAPI.Controllers
{
    [ApiController]
    [Route("api/trade")]
    public class TradeController : ControllerBase
    {
        private readonly TradeService _tradeService;

        public TradeController(TradeService tradeService)
        {
            _tradeService = tradeService;
        }

        /// <summary>
        /// 通貨の売買を処理する。
        /// </summary>
        /// <param name="tradeDto">取引情報を含むDTO</param>
        /// <returns>取引結果</returns>
        [HttpPost]
        public async Task<IActionResult> ExecuteTrade([FromBody] TradeDto tradeDto)
        {
            var result = await _tradeService.ExecuteTradeAsync(tradeDto);
            if (!result)
                return BadRequest("Trade execution failed");

            return Ok("Trade executed successfully");
        }

        //取引履歴取得
        [HttpGet("history/{userId}")]
        public async Task<IActionResult> GetTradeHistory(int userId)
        {
            var trades = await _tradeService.GetTradeHistoryAsync(userId);
            if (trades == null || trades.Count == 0)
                return NotFound();

            return Ok(trades);
        }

    }
}
