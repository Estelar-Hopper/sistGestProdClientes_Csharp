using System.Security.AccessControl;
using ApiRestFul.Domain.Repositories;
using ApiRestFul.Domain.Models;
using ApiRestFul.Infrastructure.Data;
using ApiRestFul.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiRestFul.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;
    
    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }
    
    
    // Obtener todos los registros
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.customers_tb.ToListAsync();
    }
    
    
    // Obtener un registro por Id
    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _context.customers_tb.FirstOrDefaultAsync(c => c.Id == id);
    }
    
    
    // Crear un nuevo registro
    public async Task<Customer> CreateAsync(Customer customer)
    {
        _context.customers_tb.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }
    
    
    // Actualizar un registro ya existente
    public async Task<Customer?> UpdateAsync(Customer customer)
    {
        var existing = await _context.customers_tb.FindAsync(customer.Id);
        if (existing == null)
            return null;

        existing.Name = customer.Name;
        existing.Email = customer.Email;

        await _context.SaveChangesAsync();
        return existing;
    }
    
    
    // Eliminar un registro por Id
    public async Task<bool> DeleteAsync(int id)
    {
        var customer = await _context.customers_tb.FindAsync(id);
        if (customer == null)
            return false;

        _context.customers_tb.Remove(customer);
        await _context.SaveChangesAsync();
        return true;
    }
    
}