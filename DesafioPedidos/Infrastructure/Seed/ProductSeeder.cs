using DesafioPedidos.Domain.Entities;
using DesafioPedidos.Infrastructure.Data.Context;

public static class ProductSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Products.Any())
        {
            context.Products.AddRange(
                new Product { ProductName = "Product A", Price = 10.00M },
                new Product { ProductName = "Product B", Price = 20.00M }
            );
            
            context.SaveChanges();
        }
    }
}
