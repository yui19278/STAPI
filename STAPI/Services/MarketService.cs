using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using STAPI.Data;
using STAPI.Models;
using STAPI.DTOs;

namespace STAPI.Services
{
    public class MarketService
    {
        private readonly StockGameDbContext _context;
        private readonly Dictionary<string, decimal> _marketData;
        private readonly Random _random;

        public MarketService(StockGameDbContext context)
        {
            _context = context;
            _marketData = new Dictionary<string, decimal>
            {
                { "CurrencyA", 1.0m },
                { "CurrencyB", 1.0m }
            };
            _random = new Random();

            // 非同期で市場シミュレーションを開始
            Task.Run(() => StartMarketSimulationAsync());
        }

        public MarketDto GetMarketData()
        {
            return new MarketDto
            {
                CurrencyA = _marketData["CurrencyA"],
                CurrencyB = _marketData["CurrencyB"]
            };
        }

        private async Task StartMarketSimulationAsync()
        {
            while (true)
            {
                await Task.Delay(1000); // 1秒待機
                foreach (var key in _marketData.Keys.ToList())
                {
                    var change = (decimal)_random.NextDouble() * 0.01m - 0.005m;
                    _marketData[key] += _marketData[key] * change;
                }
            }
        }
    }
}
