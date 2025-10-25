using ApiRestFul.Application.Services;
using ApiRestFul.Domain.Interfaces.Services;
using ApiRestFul.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace estelar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }
    
        // Obtener todos los productos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }
        
        
        // Obtener producto por Id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);

            if (customer == null)
                return NotFound(new { message = $"Customer with ID {id} not found." });

            return Ok(customer);
        }
        
        
        
        
        // Crear un nuevo producto
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCustomer = await _customerService.CreateAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = createdCustomer.Id }, createdCustomer);
        }
        
        
        
        // Actualizar un producto existente
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
                return BadRequest(new { message = "Customer ID mismatch." });

            var updated = await _customerService.UpdateAsync(customer);

            if (!updated)
                return NotFound(new { message = $"Customer with ID {id} not found." });

            return NoContent();
        }

        
        // Eliminar un producto
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _customerService.DeleteAsync(id);

            if (!deleted)
                return NotFound(new { message = $"Customer with ID {id} not found." });

            return NoContent();
        }
        
    }
}

