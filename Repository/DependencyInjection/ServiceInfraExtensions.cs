using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Repository.DependencyInjection
{
    public static class ServiceInfraExtensions
    {
        
        public static IServiceCollection AddDataBasePostgresService(this IServiceCollection services) 
        {            
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IPedidoStatusRepository, PedidoStatusRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            return services;
        }

    }
}
