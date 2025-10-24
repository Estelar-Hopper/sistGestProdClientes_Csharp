using ApiRestFul.Application.Services;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore; 
using ApiRestFul.Infrastructure.Data;
using ApiRestFul.Domain.Models;
using ApiRestFul.Domain.Repositories;
using ApiRestFul.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var ConnectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddControllers();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{

    //  Le pasamos el string de conexión
    // Le decimos que autodetecte la versión del servidor MySQL
    options.UseMySql(
        ConnectionString, 
        ServerVersion.AutoDetect(ConnectionString),
        
        // Mantenemos la configuración de las migraciones
        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
    );
});

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

app.MapControllers();

app.Run();

