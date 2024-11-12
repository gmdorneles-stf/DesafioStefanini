using DesafioPedidos.Domain.Entities;

namespace DesafioPedidos.Infrastructure.Data.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> GetByIdAsync(int orderId, int productId);
        Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId);
        Task AddAsync(OrderItem orderItem);
        void Delete(OrderItem orderItem);
        Task SaveChangesAsync();
    }
}
