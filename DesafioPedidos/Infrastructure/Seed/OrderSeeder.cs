using DesafioPedidos.Domain.Entities;
using DesafioPedidos.Infrastructure.Data.Context;

namespace DesafioPedidos.Infrastructure.Seed
{
    public class OrderSeeder
    {
        public static void Seed(AppDbContext context)
        {
            context.Order.AddRange(
                new Order
                {
                    CustomerName = "John Doe",
                    CustomerEmail = "john.doe@example.com",
                    CreationDate = DateTime.Now,
                    IsPaid = true
                },
                new Order
                {
                    CustomerName = "Jane Smith",
                    CustomerEmail = "jane.smith@example.com",
                    CreationDate = DateTime.Now.AddDays(-1),
                    IsPaid = false
                }
            );

            context.OrderItem.AddRange(
                new OrderItem { OrderId = 1, ProductId = 1, Quantity = 2 },
                new OrderItem { OrderId = 1, ProductId = 2, Quantity = 1 },
                new OrderItem { OrderId = 2, ProductId = 2, Quantity = 3 },
                new OrderItem { OrderId = 2, ProductId = 1, Quantity = 1 }
            );

            context.SaveChanges();
        }
    }
}
