using Newtonsoft.Json;
using Products.API.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Products.API.Model
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public string Producer { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Dictionary<string, string> Specification { get; set; }

        [Required]
        public int AvailableQuantity { get; set; }
    }
}
