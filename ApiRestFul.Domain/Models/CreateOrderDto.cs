namespace ApiRestFul.Domain.Models;

public class CreateOrderDto
{
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = string.Empty;
}