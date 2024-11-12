using DesafioPedidos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioPedidos.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        void Update(Product product);
        void Delete(Product product);
        Task SaveChangesAsync();
    }
}
