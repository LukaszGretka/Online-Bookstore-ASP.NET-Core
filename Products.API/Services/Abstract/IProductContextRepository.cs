using Products.API.Model;
using System.Threading.Tasks;

namespace Products.API.Services.Abstract
{
    public interface IProductContextRepository
    {
        Task<Product> GetProductByIdAsync(int id);

        Task<int> AddProductAsync(Product product);

        Task<Product> UpdateProductAsync(Product product);

        Task<Product> DeleteProductByIdAsync(int id);
    }
}
