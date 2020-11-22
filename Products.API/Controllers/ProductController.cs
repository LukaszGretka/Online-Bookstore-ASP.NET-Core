using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.API.Common;
using Products.API.Database;
using Products.API.Model;
using Products.API.Services.Abstract;

namespace Products.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductContextRepository _productDbRepository;

        public ProductController(IProductContextRepository productRepository)
        {
            _productDbRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpPost]
        [Route("add")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddProductAsync([FromBody] Product product)
        {
            var productItem = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Producer = product.Producer,
                Category = product.Category,
                Specification = product.Specification,
            };

            await _productDbRepository.AddProductAsync(productItem);

            return CreatedAtAction(nameof(GetProductByIdAsync), new { id = productItem.ID }, productItem);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ActionName(nameof(GetProductByIdAsync))]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ErrorResponse.InvalidParameterValue(nameof(id)));
            }

            var product = await _productDbRepository.GetProductByIdAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            return product;
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> UpdateProductAsync([FromBody] Product productToUpdate)
        {
            if (productToUpdate.ID <= 0)
            {
                return BadRequest(ErrorResponse.InvalidParameterValue(nameof(productToUpdate.ID)));
            }

            await _productDbRepository.UpdateProductAsync(productToUpdate);

            return CreatedAtAction(nameof(GetProductByIdAsync), new { id = productToUpdate.ID }, productToUpdate);
        }

        [Route("remove/{id:int}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DeleteProductByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ErrorResponse.InvalidParameterValue(nameof(id)));
            }

            var productItem = await _productDbRepository.DeleteProductByIdAsync(id);

            if (productItem is null)
            {
               return NotFound(ErrorResponse.ItemWithIdNotFound(nameof(productItem), id));
            }
            
            return NoContent();
        }
    }
}
