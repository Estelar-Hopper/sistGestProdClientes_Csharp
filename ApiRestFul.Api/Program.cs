using ApiRestFul.Application.Services;
using ApiRestFul.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore; 
using ApiRestFul.Infrastructure.Data;
using ApiRestFul.Domain.Models;
using ApiRestFul.Domain.Repositories;
using ApiRestFul.Infrastructure.Extensions;
using ApiRestFul.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


// ---------------------------------------------------------------
// Inyeccion de DB context
builder.Services.AddInfrastructure(builder.Configuration);

// Otras inyecciones
builder.Services.AddControllers();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<CustomerService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<OrderService>();


// ---------------------------------------------------------------


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Obligatorio para mapear los controllers
app.MapControllers();

app.Run();

//test commit