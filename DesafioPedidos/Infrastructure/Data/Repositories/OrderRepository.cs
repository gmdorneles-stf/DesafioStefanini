using DesafioPedidos.Domain.Entities;
using DesafioPedidos.Infrastructure.Data.Context;
using DesafioPedidos.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioPedidos.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Order
                .Include(o => o.OrderItems)  
                .ThenInclude(oi => oi.Product) 
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Order
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            await _context.Order.AddAsync(order);
        }

        public void Update(Order order)
        {
            _context.Order.Update(order);
        }

        public void Delete(Order order)
        {
            _context.Order.Remove(order);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
