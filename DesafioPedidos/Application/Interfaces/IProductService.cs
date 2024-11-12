using DesafioPedidos.Application.Models.Requests;
using DesafioPedidos.Domain.Entities;

namespace DesafioPedidos.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task AddProductAsync(PostProductRequest product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
