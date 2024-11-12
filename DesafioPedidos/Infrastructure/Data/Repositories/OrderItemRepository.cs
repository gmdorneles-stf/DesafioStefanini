using DesafioPedidos.Domain.Entities;
using DesafioPedidos.Infrastructure.Data.Context;
using DesafioPedidos.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioPedidos.Infrastructure.Data.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext _context;
        public OrderItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrderItem> GetByIdAsync(int orderId, int productId)
        {
            return await _context.OrderItem
                .FirstOrDefaultAsync(oi => oi.OrderId == orderId && oi.ProductId == productId);
        }
        public async Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId)
        {
            return await _context.OrderItem
                .Where(oi => oi.OrderId == orderId)
                .Include(oi => oi.Product)  // Optional: Include related Product
                .ToListAsync();
        }

        public async Task AddAsync(OrderItem orderItem)
        {
            await _context.OrderItem.AddAsync(orderItem);
        }

        public void Delete(OrderItem orderItem)
        {
            _context.OrderItem.Remove(orderItem);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
