using DesafioPedidos.Application.Interfaces;
using DesafioPedidos.Application.Models.Requests;
using DesafioPedidos.Domain.Entities;
using DesafioPedidos.Infrastructure.Data.Interfaces;

namespace DesafioPedidos.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductService _productService;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IProductService productService)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _productService = productService;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task AddOrderAsync(PostOrderRequest request)
        {
            var products = await _productService.GetAllProductsAsync();

            if (!request.Products.All(req => products.Any(p => p.Id == req.ProductId)))
            {
                throw new Exception("Product Not Found");
            }

            var order = new Order
            {
                CustomerName = request.CustomerName,
                CustomerEmail = request.CustomerEmail,
                OrderItems = request.Products.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Product = products.FirstOrDefault(p => p.Id == item.ProductId)
                }).ToList()
            };

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _orderRepository.Update(order);
            await _orderRepository.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order != null)
            {
                _orderRepository.Delete(order);
                await _orderRepository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderId)
        {
            return await _orderItemRepository.GetByOrderIdAsync(orderId);
        }

        public async Task AddOrderItemAsync(OrderItem orderItem)
        {
            await _orderItemRepository.AddAsync(orderItem);
            await _orderItemRepository.SaveChangesAsync();
        }

        public async Task RemoveOrderItemAsync(int orderId, int productId)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(orderId, productId);
            if (orderItem != null)
            {
                _orderItemRepository.Delete(orderItem);
                await _orderItemRepository.SaveChangesAsync();
            }
        }
    }
}
