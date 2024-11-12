namespace DesafioPedidos.Application.Models.Requests
{
    public class PostProductRequest
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
