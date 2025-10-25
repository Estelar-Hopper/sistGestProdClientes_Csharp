using ApiRestFul.Domain.Repositories;
using ApiRestFul.Domain.Models;
using ApiRestFul.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiRestFul.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todas las órdenes
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            // Incluimos Cliente y Detalles para tener la información completa
            return await _context.orders_tb
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                .ToListAsync();
        }

        // Obtener una orden por Id (con sus detalles)
        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.orders_tb
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails) // Incluye los detalles de la orden
                .ThenInclude(od => od.Product) // Opcional: si quieres incluir el producto en cada detalle
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        // Crear una nueva orden (EF Core manejará los OrderDetails si vienen en el objeto)
        public async Task<Order> CreateAsync(Order order)
        {
            // Asignamos la fecha actual al crear la orden
            order.OrderDate = DateTime.UtcNow;
            _context.orders_tb.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        // Actualizar una orden 
        public async Task<Order?> UpdateAsync(Order order)
        {
            var existing = await _context.orders_tb.FindAsync(order.Id);
            if (existing == null)
                return null;

            // actualizar el estado
            existing.Status = order.Status;
            


            await _context.SaveChangesAsync();
            return existing;
        }

        // Eliminar una orden por Id
        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _context.orders_tb.FindAsync(id);
            if (order == null)
                return false;


            // Por simplicidad, aquí solo eliminamos la orden.
            _context.orders_tb.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}