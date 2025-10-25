using ApiRestFul.Application.Services;
using ApiRestFul.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestFul.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }
        

        // GET: api/order
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        // GET: api/order/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);

            if (order == null)
                return NotFound(new { message = $"Order with ID {id} not found." });

            return Ok(order);
        }

        // POST: api/order
        // El enunciado pide "Crear un nuevo pedido con sus productos"
        // [HttpPost]
        // public async Task<IActionResult> Create([FromBody] Order order)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);
        //
        //     var createdOrder = await _orderService.CreateAsync(order);
        //     
        //     // Devuelve el objeto creado y la URL para consultarlo (GetById)
        //     return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
        // }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Mapear manualmente el DTO a tu entidad Order
            var order = new Order
            {
                CustomerId = dto.CustomerId,
                OrderDate = dto.OrderDate,
                Status = dto.Status
            };

            var createdOrder = await _orderService.CreateAsync(order);

            return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
        }

        
        
        
        // PUT: api/order/5
        // El enunciado pide "Actualizar el estado de un pedido"
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Order order)
        {
            if (id != order.Id)
                return BadRequest(new { message = "Order ID mismatch." });
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _orderService.UpdateAsync(order);

            if (!updated)
                return NotFound(new { message = $"Order with ID {id} not found." });

            return NoContent(); // Éxito, sin contenido que devolver
        }

        // DELETE: api/order/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _orderService.DeleteAsync(id);

            if (!deleted)
                return NotFound(new { message = $"Order with ID {id} not found." });

            return NoContent(); // Éxito, sin contenido que devolver
        }
    }
}