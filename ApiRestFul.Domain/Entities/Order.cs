using System.ComponentModel.DataAnnotations.Schema;


namespace ApiRestFul.Domain.Models;

public class Order
{
    public int Id { get; set; }
    
    public int CustomerId { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public string Status { get; set; } = String.Empty;

    
    // To stablish the relation with other tables:
    public Customer Customer { get; set; }
    
    
    //Relation 1:n
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}