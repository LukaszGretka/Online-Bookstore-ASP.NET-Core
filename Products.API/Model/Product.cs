using System.ComponentModel.DataAnnotations;

namespace Products.API.Model
{
    abstract public class Product
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal? Price { get; set; }
    }
}
