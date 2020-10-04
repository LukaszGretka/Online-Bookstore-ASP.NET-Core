using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.API.Database;
using Products.API.Model;

namespace Products.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductContext _productContext;

        public ProductController(ProductContext productContext)
        {
            _productContext = productContext ?? throw new ArgumentNullException(nameof(productContext));
        }

        [HttpPost]
        [Route("book/add")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddNewBookAsync([FromBody]ProductBook book)
        {
            var productBook = new ProductBook
            {
                Title = book.Title,
                Description = book.Description,
                Genre = book.Genre,
                Pages = book.Pages,
                Price = book.Price
            };

            _productContext.Books.Add(productBook);
            await _productContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookByIdAsync), new { id = productBook.ID }, productBook);
        }

        [HttpGet]   
        [Route("book/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProductBook), (int)HttpStatusCode.OK)]
        [ActionName(nameof(GetBookByIdAsync))]
        public async Task<ActionResult<ProductBook>> GetBookByIdAsync(int id)
        {
            var book = await _productContext.Books.SingleOrDefaultAsync(book => book.ID == id);

            if (book is null)
            {   
                return NotFound();
            }

            return book;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
