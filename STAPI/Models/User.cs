using System.ComponentModel.DataAnnotations;

namespace STAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CurrencyABalance { get; set; }
        public decimal CurrencyBBalance { get; set; }
    }
}
