using Microsoft.AspNetCore.Mvc;
using ApiRestFul.Application.Services;
using ApiRestFul.Domain.Models;

namespace ApiRestFul.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailService _orderDetailService;

        public OrderDetailController(OrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        // GET: api/orderdetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetAll()
        {
            var result = await _orderDetailService.GetAllAsync();
            return Ok(result);
        }

        // GET: api/orderdetail/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> GetById(int id)
        {
            var detail = await _orderDetailService.GetByIdAsync(id);
            if (detail == null)
                return NotFound();

            return Ok(detail);
        }

        // POST: api/orderdetail
        [HttpPost]
        public async Task<ActionResult<OrderDetail>> Create([FromBody] OrderDetail detail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _orderDetailService.CreateAsync(detail);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/orderdetail/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrderDetail detail)
        {
            if (id != detail.Id)
                return BadRequest("ID mismatch");

            var success = await _orderDetailService.UpdateAsync(detail);
            if (!success)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/orderdetail/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _orderDetailService.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
