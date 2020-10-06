using Newtonsoft.Json;
using Products.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace Products.API.Model
{
    public class Processor : Product
    {
        [Required]
        public string Socket { get; set; }

        [Required]
        public float? StandardFrequency { get; set; }

        [Required]
        public float? TurboFrequency { get; set; }
    }
}
