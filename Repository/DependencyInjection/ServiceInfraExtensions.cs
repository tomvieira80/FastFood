using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;

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
