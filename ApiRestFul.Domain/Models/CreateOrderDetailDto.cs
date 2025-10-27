namespace ApiRestFul.Domain.Models;

public class CreateOrderDetailDto
{
    public int OrderId { get; set; }
    
    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }
}