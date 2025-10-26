using ApiRestFul.Domain.Repositories;
using ApiRestFul.Domain.Models;
using ApiRestFul.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiRestFul.Infrastructure.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly AppDbContext _context;

        public OrderDetailRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get all order details
        public async Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            return await _context.orderDetails_tb
                .Include(od => od.Order)
                .Include(od => od.Product)
                .ToListAsync();
        }

        // Get order detail by ID
        public async Task<OrderDetail?> GetByIdAsync(int id)
        {
            return await _context.orderDetails_tb
                .Include(od => od.Order)
                .Include(od => od.Product)
                .FirstOrDefaultAsync(od => od.Id == id);
        }

        // Create a new order detail
        public async Task<OrderDetail> CreateAsync(OrderDetail orderDetail)
        {
            _context.orderDetails_tb.Add(orderDetail);
            await _context.SaveChangesAsync();
            return orderDetail;
        }

        // Update an order detail
        public async Task<OrderDetail?> UpdateAsync(OrderDetail orderDetail)
        {
            var existing = await _context.orderDetails_tb.FindAsync(orderDetail.Id);
            if (existing == null)
                return null;

            // Update fields
            existing.ProductId = orderDetail.ProductId;
            existing.Quantity = orderDetail.Quantity;
            existing.UnitPrice = orderDetail.UnitPrice;
            existing.OrderId = orderDetail.OrderId;

            await _context.SaveChangesAsync();
            return existing;
        }

        // Delete an order detail
        public async Task<bool> DeleteAsync(int id)
        {
            var detail = await _context.orderDetails_tb.FindAsync(id);
            if (detail == null)
                return false;

            _context.orderDetails_tb.Remove(detail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
