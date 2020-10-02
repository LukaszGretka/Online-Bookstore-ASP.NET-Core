using Products.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.API.Model
{
    public class ProductBook
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public int Pages { get; set; }

        public Genre Genre { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
