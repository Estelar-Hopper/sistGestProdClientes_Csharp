using ApiRestFul.Domain.Repositories;
using ApiRestFul.Domain.Models;

namespace ApiRestFul.Application.Services
{
    public class OrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        // Get all order details
        public async Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            return await _orderDetailRepository.GetAllAsync();
        }

        // Get order detail by ID
        public async Task<OrderDetail?> GetByIdAsync(int id)
        {
            return await _orderDetailRepository.GetByIdAsync(id);
        }

        // Create new order detail
        public async Task<OrderDetail> CreateAsync(OrderDetail orderDetail)
        {
            // Business logic example: validate quantity or price
            if (orderDetail.Quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            if (orderDetail.UnitPrice <= 0)
                throw new ArgumentException("Unit price must be greater than zero.");

            return await _orderDetailRepository.CreateAsync(orderDetail);
        }

        // Update an order detail
        public async Task<bool> UpdateAsync(OrderDetail orderDetail)
        {
            var existing = await _orderDetailRepository.GetByIdAsync(orderDetail.Id);
            if (existing == null)
                return false;

            var updated = await _orderDetailRepository.UpdateAsync(orderDetail);
            return updated != null;
        }

        // Delete order detail by ID
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _orderDetailRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            return await _orderDetailRepository.DeleteAsync(id);
        }
    }
}