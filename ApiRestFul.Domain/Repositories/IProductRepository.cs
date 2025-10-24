using ApiRestFul.Domain.Models;

namespace ApiRestFul.Domain.Repositories;

public interface IProductRepository
{
    public Task<Product?> GetByIdAsync(int id);
}