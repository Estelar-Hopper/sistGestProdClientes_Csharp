using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestFul.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int ProductCode { get; set; } 
    public bool Available { get; set; }


    //Relation 1:n
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

}