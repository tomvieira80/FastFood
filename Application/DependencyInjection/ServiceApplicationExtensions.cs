using Application.Services;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Application.DependencyInjection
{
    public static class ServiceApplicationExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services) 
        {
            services.AddTransient<IClienteService, ClienteService>();
            return services;
        }
    }
}
