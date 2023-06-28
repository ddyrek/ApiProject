using System.ComponentModel.DataAnnotations;

namespace Groomer.Client.Models
{
    public class KontrahentFormularz
    {
        [Required]
        public string? NazwaFirmy { get; set; }
        [Required]
        public string? Ulica { get; set; }
        [Required]
        public string? NumerBudynku { get; set; }
        public string? NumerLokalu { get; set; }
        [Required]
        public string? Nip { get; set; }
    }
}
