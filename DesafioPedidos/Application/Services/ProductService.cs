using DesafioPedidos.Application.Interfaces;
using DesafioPedidos.Application.Models.Requests;
using DesafioPedidos.Domain.Entities;
using DesafioPedidos.Domain.Repositories;

namespace DesafioPedidos.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task AddProductAsync(PostProductRequest product)
        {
            var newProduct = new Product {
                ProductName = product.ProductName,
                Price = product.Price
            };
            await _productRepository.AddAsync(newProduct);
            await _productRepository.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null)
            {
                _productRepository.Delete(product);
                await _productRepository.SaveChangesAsync();
            }
        }
    }
}
