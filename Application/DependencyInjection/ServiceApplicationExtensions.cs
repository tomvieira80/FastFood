using Application.Services;
using Application.Validators;
using Domain.Services;
using Domain.Validators;
using Microsoft.Extensions.DependencyInjection;


namespace Application.DependencyInjection
{
    public static class ServiceApplicationExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services) 
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IClienteValidator, ClienteValidator>();
            services.AddScoped<IPedidoStatusService, PedidoStatusService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoValidator, ProdutoValidator>();
            return services;
        }
    }
}
