using ApiRestFul.Domain.Repositories;
using ApiRestFul.Domain.Models;
using ApiRestFul.Infrastructure.Data;

namespace ApiRestFul.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var product = await _context.products_tb.FindAsync(id);
        return product;
    }
}