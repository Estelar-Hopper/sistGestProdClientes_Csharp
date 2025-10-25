using ApiRestFul.Domain.Models;

namespace ApiRestFul.Domain.Interfaces.Services;

public interface ICustomerService
{
    public Task<Customer> CreateCustomerAsync(Customer customer);
    public Task<List<Customer>> GetCustomerAsync();
    public Task<Customer> GetCustomer(int id);
    public Task<Customer> EditCustomer(int id);
    public Task<Customer> DeleteCustomer(int id);
}