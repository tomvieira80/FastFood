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
            services.AddTransient<IClienteService, ClienteService>();
            services.AddScoped<IClienteValidator, ClienteValidator>();
            return services;
        }
    }
}
