using ApiRestFul.Domain.Interfaces.Repositories;
using ApiRestFul.Domain.Interfaces.Services;
using ApiRestFul.Domain.Models;


namespace ApiRestFul.Application.Services
{

    public class CustomerService
    {
        // Implementar interface de ICustomerRepository
        private readonly ICustomerRepository _customerRepository;

        // Ctor de ICustomerRepository
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        // Obtener todos los registros
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }


        // Obtener un registro por su ID
        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }


        // Crear un nuevo registro
        public async Task<Customer> CreateAsync(Customer customer)
        {
            return await _customerRepository.CreateAsync(customer);
        }


        // Actualizar un registro ya existente
        public async Task<bool> UpdateAsync(Customer customer)
        {
            var existing = await _customerRepository.GetByIdAsync(customer.Id);
            if (existing == null)
                return false;

            await _customerRepository.UpdateAsync(customer);
            return true;
        }



        // Eliminar un registro por su ID
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _customerRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            return await _customerRepository.DeleteAsync(id);
        }

    }
}