using DesafioPedidos.Domain.Entities;

namespace DesafioPedidos.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Order> GetOrderByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);

        Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderId);
        Task AddOrderItemAsync(OrderItem orderItem);
        Task RemoveOrderItemAsync(int orderId, int productId);
    }
}
