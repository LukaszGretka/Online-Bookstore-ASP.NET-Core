using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.API.Database;
using Products.API.Model;

namespace Products.API.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _productContext;

        public ProductController(ProductContext productContext)
        {
            _productContext = productContext ?? throw new ArgumentNullException(nameof(productContext)); ;
        }

        [HttpGet]
        [Route("book/{id:int}")]
        public async Task<ActionResult<ProductBook>> GetBookByIdAsync(int id)
        {
            var book = await _productContext.Books.SingleOrDefaultAsync(book => book.ID == id);

            if (book is null)
                return NotFound();

            return book;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
