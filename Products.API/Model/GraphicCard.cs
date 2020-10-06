
using System.ComponentModel.DataAnnotations;

namespace Products.API.Model
{
    public class GraphicCard : Product
    {
        [Required]
        public int? CoreFrequency { get; set; }

        [Required]
        public int? BoostCoreFrequency { get; set; }

        [Required]
        public string Chipset { get; set; }

        [Required]
        public int Memory { get; set; }

        [Required]
        public int MemoryFrequency { get; set; }
    }
}
