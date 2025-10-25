using ApiRestFul.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiRestFul.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string conn = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(
                conn,
                //Para especificar la version sin autodetect
                // new MySqlServerVersion(new Version(8,0,36))
                ServerVersion.AutoDetect(conn)
            )
        );
        return services;
    }
    
}
