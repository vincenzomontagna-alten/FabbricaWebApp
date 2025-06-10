using System.ComponentModel.DataAnnotations;

namespace FabbricaWebApp.Models
{
    public class ProdottoTerminato
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Il valore deve essere maggiore o uguale a 0.")]

        public int Id { get; set; }

        [Required]
        public string? NomeProdotto { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Il valore deve essere maggiore o uguale a 0.")]
        public int Quantita { get; set; }
    }
}
