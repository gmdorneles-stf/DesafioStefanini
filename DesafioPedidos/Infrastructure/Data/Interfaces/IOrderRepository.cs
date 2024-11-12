using DesafioPedidos.Domain.Entities;

namespace DesafioPedidos.Infrastructure.Data.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task AddAsync(Order order);
        void Update(Order order);
        void Delete(Order order);
        Task SaveChangesAsync();
    }
}
