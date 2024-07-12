using System.ComponentModel.DataAnnotations;

namespace STAPI.Models
{
    public class Currency
    {
        [Key]
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
