using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Products.API.Database;
using Products.API.Model;
using Products.API.Services.Abstract;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Products.API.Services
{
    public class ProductContextRepository : IProductContextRepository
    {
        private readonly ProductContext _productContext;
        private readonly ILogger _logger;

        public ProductContextRepository(ProductContext productContext, ILogger logger)
        {
            _productContext = productContext ?? throw new ArgumentNullException(nameof(productContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await _productContext.Product.SingleOrDefaultAsync(item => item.ID == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                // TODO: return generic/filtered exception message to client
                return null;
            }
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var productItem = await _productContext.Product.AsNoTracking()
                                         .SingleOrDefaultAsync(item => item.ID == product.ID);

            if (productItem is null)
            {
                return productItem;
            }

            productItem = product;
            _productContext.Product.Update(productItem);

            await _productContext.SaveChangesAsync();

            return productItem;
        }

        public async Task<int> AddProductAsync(Product product)
        {

            return await _productContext.SaveChangesAsync();
        }

        public async Task<Product> DeleteProductByIdAsync(int id)
        {
            var productItem = _productContext.Product.SingleOrDefault(item => item.ID.Equals(id));

            if (productItem is null)
            {
                return productItem;
            }

            _productContext.Product.Remove(productItem);
            await _productContext.SaveChangesAsync();

            return productItem;
        }
    }
}
