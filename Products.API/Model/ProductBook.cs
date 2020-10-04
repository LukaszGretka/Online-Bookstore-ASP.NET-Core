using Newtonsoft.Json;
using Products.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace Products.API.Model
{
    public class ProductBook
    {
        public int ID { get; private set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int? Pages { get; set; }

        [Required]
        public Genre? Genre { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal? Price { get; set; }
    }
}
