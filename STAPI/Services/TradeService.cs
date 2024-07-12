using STAPI.Data;
using STAPI.Models;
using STAPI.DTOs;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace STAPI.Services
{
    public class TradeService
    {
        private readonly StockGameDbContext _context;
        private readonly MarketService _marketService;

        public TradeService(StockGameDbContext context, MarketService marketService)
        {
            _context = context;
            _marketService = marketService;
        }

        public async Task<bool> ExecuteTradeAsync(TradeDto tradeDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == tradeDto.UserId);
            if (user == null)
                return false;

            var marketData = _marketService.GetMarketData();
            decimal rate = tradeDto.CurrencyName == "CurrencyA" ? marketData.CurrencyA : marketData.CurrencyB;
            decimal cost = tradeDto.Amount * rate * tradeDto.Leverage;

            if (tradeDto.CurrencyName == "CurrencyA")
            {
                if (user.CurrencyABalance < cost)
                    return false;
                user.CurrencyABalance -= cost;
            }
            else
            {
                if (user.CurrencyBBalance < cost)
                    return false;
                user.CurrencyBBalance -= cost;
            }

            var trade = new Trade
            {
                UserId = tradeDto.UserId,
                CurrencyName = tradeDto.CurrencyName,
                Amount = tradeDto.Amount,
                Leverage = tradeDto.Leverage
            };

            await _context.Trades.AddAsync(trade);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<List<Trade>> GetTradeHistoryAsync(int userId)
        {
            return await _context.Trades.Where(t => t.UserId == userId).ToListAsync();
        }

    }
}
