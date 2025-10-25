namespace ApiRestFul.Domain.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    
    // Relation 1:n
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}