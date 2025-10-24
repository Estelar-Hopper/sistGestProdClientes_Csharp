using ApiRestFul.Domain.Repositories;
using ApiRestFul.Domain.Models;
using ApiRestFul.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiRestFul.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todos los productos (con relación opcional a OrderDetails)
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.products_tb
                .Include(p => p.OrderDetails) // Opcional: quítalo si no quieres cargar relaciones
                .ToListAsync();
        }

        // Obtener un producto por Id
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.products_tb
                .Include(p => p.OrderDetails) // también opcional
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // Crear un nuevo producto
        public async Task<Product> CreateAsync(Product product)
        {
            _context.products_tb.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        // Actualizar un producto existente
        public async Task<Product?> UpdateAsync(Product product)
        {
            var existing = await _context.products_tb.FindAsync(product.Id);
            if (existing == null)
                return null;

            existing.ProductName = product.ProductName;
            existing.ProductCode = product.ProductCode;
            existing.Available = product.Available;

            await _context.SaveChangesAsync();
            return existing;
        }

        // Eliminar un producto por Id
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.products_tb.FindAsync(id);
            if (product == null)
                return false;

            _context.products_tb.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
