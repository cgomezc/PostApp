using System.ComponentModel.DataAnnotations;
namespace PostApp.Domain.Entities
{
    public class Currency
    {
        [StringLength(100, ErrorMessage = "Currency name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [StringLength(3, MinimumLength = 3, ErrorMessage = "Currency code must be exactly 3 characters.")]
        public string CurrencyCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "At least one denomination is required.")]
        public List<Denomination> Denominations { get; set; }
      
        public Currency() { }
    }


}
