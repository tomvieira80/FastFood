using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Repository.DependencyInjection
{
    public static class ServiceInfraExtensions
    {
        
        public static IServiceCollection AddDataBasePostgresService(this IServiceCollection services) 
        {            
            services.AddScoped<IClienteRepository, ClienteRepository>();
            return services;
        }

    }
}
