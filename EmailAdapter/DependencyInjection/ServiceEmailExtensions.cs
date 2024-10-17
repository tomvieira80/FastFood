using Domain.Services;
using EmailAdapter.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace EmailAdapter.DependencyInjection
{
    public static class ServiceEmailExtensions
    {
        public static IServiceCollection AddEmailService(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, FakeEmailAdapter>();
            return services;
        }
    }
}
