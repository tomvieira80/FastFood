using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using PagamentoAdapter.Operations;

namespace PagamentoAdapter.DependencyInjection
{
    public static class ServicePagamentoExtensions
    {
        public static IServiceCollection AddPagamentoService(this IServiceCollection services)
        {
            services.AddTransient<IPagamentoService, FakePagamentoAdapter>();
            return services;
        }
    }
}
