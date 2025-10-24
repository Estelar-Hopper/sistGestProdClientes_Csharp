using ApiRestFul.Application.Services;
using ApiRestFul.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRestFul.Infrastructure.Data;

namespace ApiRestFul.Api.Controllers;

//Do not forget these labels
[ApiController]
[Route("api/[controller]")]

public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("ping")]
    public async Task<IActionResult> Ping()
    {
        return Ok("PONG");
    }

    
    // [HttpGet]
    // public async Task<IActionResult> GetAll()
    // {
    //     var products = await _productService.GetAllAsync();
    //     return Ok(products);
    // }
    
    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetById(int id)
    // {
    //     var product = await _service.GetByIdAsync(id);
    //     return Ok(product);
    // }
    //
    // [HttpPost]
    // public async Task<IActionResult> Create(Product product)
    // {
    //     
    // }
}