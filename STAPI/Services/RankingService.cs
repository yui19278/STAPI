using System.Linq;
using STAPI.Data;
using STAPI.Models;
using STAPI.DTOs;

namespace STAPI.Services
{
    public class RankingService
    {
        private readonly StockGameDbContext _context;

        public RankingService(StockGameDbContext context)
        {
            _context = context;
        }

        public RankingDto GetRankings()
        {
            var users = _context.Users.ToList();
            var rankings = users.Select(user => new UserRankingDto
            {
                UserId = user.Id,
                UserName = user.Name,
                TotalValue = user.CurrencyABalance + user.CurrencyBBalance
            })
            .OrderByDescending(r => r.TotalValue)
            .ToList();

            return new RankingDto { Rankings = rankings };
        }
    }
}
