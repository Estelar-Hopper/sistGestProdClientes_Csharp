using ApiRestFul.Domain.Repositories;
using ApiRestFul.Domain.Models;

namespace ApiRestFul.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        // Opcional: podrías inyectar IProductRepository o ICustomerRepository si necesitaras validaciones cruzadas

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // Obtener todas las órdenes
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        // Obtener una orden por ID
        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        // Crear una nueva orden
        public async Task<Order> CreateAsync(Order order)
        {
            // Aquí podrías agregar lógica de negocio.
            // Por ejemplo, validar que el CustomerId exista,
            // verificar stock de productos (si tuvieras ese repo),
            // o asignar un estado inicial.
            if (string.IsNullOrEmpty(order.Status))
            {
                order.Status = "Pendiente"; // Estado por defecto
            }
            
            return await _orderRepository.CreateAsync(order);
        }

        // Actualizar una orden
        public async Task<bool> UpdateAsync(Order order)
        {
            var existing = await _orderRepository.GetByIdAsync(order.Id);
            if (existing == null)
                return false; // No encontrado

            var updatedOrder = await _orderRepository.UpdateAsync(order);
            return updatedOrder != null;
        }

        // Eliminar una orden por ID
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _orderRepository.GetByIdAsync(id);
            if (existing == null)
                return false; // No encontrado

            return await _orderRepository.DeleteAsync(id);
        }
    }
}