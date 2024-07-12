using System.ComponentModel.DataAnnotations;

namespace STAPI.Models
{
    public class Trade
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CurrencyName { get; set; }
        public decimal Amount { get; set; }
        public decimal Leverage { get; set; }
    }
}
