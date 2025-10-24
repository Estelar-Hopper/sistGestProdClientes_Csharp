using ApiRestFul.Domain.Repositories;
using ApiRestFul.Domain.Models;

namespace ApiRestFul.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Obtener todos los productos
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        // Obtener un producto por ID
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        // Crear un nuevo producto
        public async Task<Product> CreateAsync(Product product)
        {
            
            return await _productRepository.CreateAsync(product);
        }

        // Actualizar un producto existente
        public async Task<bool> UpdateAsync(Product product)
        {
            var existing = await _productRepository.GetByIdAsync(product.Id);
            if (existing == null)
                return false;

            await _productRepository.UpdateAsync(product);
            return true;
        }

        // Eliminar un producto por ID
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _productRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            return await _productRepository.DeleteAsync(id);
        }
    }
}