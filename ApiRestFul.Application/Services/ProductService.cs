using ApiRestFul.Domain.Repositories;
using ApiRestFul.Domain.Models;

namespace ApiRestFul.Application.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
        
    }

    
    
    // public async Task<Product> AddAsync(Product product)
    // {
    //     _context.products_tb.Add(product);
    //     await _context.SaveChangesAsync();
    //     return product;
    // }

    
    
    // public async Task<Product> UpdateAsync(int Id ,Product product)
    // {
    //     var exist = await _context.products_tb.FindAsync(Id);
    //     if (exist == null)
    //         return null;
    //
    //     exist.ProductName = product.ProductName;
    //     exist.ProductCode = product.ProductCode;
    //     exist.Available = product.Available;
    //     
    //     await _context.SaveChangesAsync();
    //     return exist;
    // }


    // public async Task<Product> DeleteAsync(int Id)
    // {
    //     var product = await _context.products_tb.FindAsync(Id);
    //     
    //     if (product ==  null)
    //         return null;
    //     
    //     _context.products_tb.Remove(product);
    //     await _context.SaveChangesAsync();
    //     return product;
    // }

   
}