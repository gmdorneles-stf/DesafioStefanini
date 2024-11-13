using DesafioPedidos.Application.DTOs;
using DesafioPedidos.Domain.Entities;
using System.Collections.ObjectModel;

namespace DesafioPedidos.Application.Models.Requests
{
    public class PostOrderRequest
    {
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public ICollection<OrderItemDTO> Products { get; set; } = new Collection<OrderItemDTO>();
    }
}
