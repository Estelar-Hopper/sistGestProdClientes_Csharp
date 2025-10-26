using ApiRestFul.Domain.Models;

namespace ApiRestFul.Domain.Repositories
{
    public interface IOrderDetailRepository
    {
        // Get all order details
        Task<IEnumerable<OrderDetail>> GetAllAsync();

        // Get order detail by ID
        Task<OrderDetail?> GetByIdAsync(int id);

        // Create new order detail
        Task<OrderDetail> CreateAsync(OrderDetail orderDetail);

        // Update an order detail
        Task<OrderDetail?> UpdateAsync(OrderDetail orderDetail);

        // Delete an order detail by ID
        Task<bool> DeleteAsync(int id);
    }
}