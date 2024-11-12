using DesafioPedidos.Application.Interfaces;
using DesafioPedidos.Application.Services;
using DesafioPedidos.Domain.Repositories;
using DesafioPedidos.Infrastructure.Data.Context;
using DesafioPedidos.Infrastructure.Data.Interfaces;
using DesafioPedidos.Infrastructure.Data.Repositories;
using DesafioPedidos.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryDb"));


//Repositories Injection
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();

//Services Injection
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    ProductSeeder.Seed(dbContext);
    OrderSeeder.Seed(dbContext);
}

app.Run();
