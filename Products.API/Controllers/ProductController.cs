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
        [Route("add/processor")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddProcessorAsync([FromBody]Processor processor)
        {
            var productProcessor = new Processor
            {
                Name = processor.Name,
                Description = processor.Description,
                Socket = processor.Socket,
                StandardFrequency = processor.StandardFrequency,
                TurboFrequency = processor.TurboFrequency,
                Price = processor.Price
            };

            _productContext.Processors.Add(productProcessor);
            await _productContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductByIdAsync), new { id = productProcessor.ID }, productProcessor);
        }


        [HttpPost]
        [Route("add/graphicCard")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddGraphicCardAsync([FromBody]GraphicCard graphicCard)
        {
            var productGraphicCard = new GraphicCard
            {
                Name = graphicCard.Name,
                Description = graphicCard.Description,
                CoreFrequency = graphicCard.CoreFrequency,
                BoostCoreFrequency = graphicCard.BoostCoreFrequency,
                Chipset = graphicCard.Chipset,
                Memory = graphicCard.Memory,
                ID = graphicCard.ID,
                Price = graphicCard.Price
            };

            _productContext.GraphicCards.Add(productGraphicCard);
            await _productContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductByIdAsync), new { id = productGraphicCard.ID }, productGraphicCard);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Processor), (int)HttpStatusCode.OK)]
        [ActionName(nameof(GetProductByIdAsync))]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            //TODO: add service for multi products
            var book = await _productContext.Processors.SingleOrDefaultAsync(book => book.ID == id);

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
