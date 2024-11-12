using System.Text.Json.Serialization;

namespace DesafioPedidos.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public bool IsPaid { get; set; }
        
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
