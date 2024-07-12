namespace STAPI.DTOs
{
    public class TradeDto
    {
        public int UserId { get; set; }
        public string CurrencyName { get; set; }
        public decimal Amount { get; set; }
        public decimal Leverage { get; set; }
    }
}