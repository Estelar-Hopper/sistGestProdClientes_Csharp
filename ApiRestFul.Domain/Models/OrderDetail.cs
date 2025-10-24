using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestFul.Domain.Models;

public class OrderDetail
{
    public int Id { get; set; }
    
    public int OrderId { get; set; }
    
    public string ProductId { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }


    // To stablish the relation:
    public Order Order { get; set; }
    public Product Product { get; set; }
    
    
}