using Microsoft.Extensions.DependencyInjection;
using ReactAdminSample.Domain.Repositories;
using ReactAdminSample.Domain.Repositories.Impl;
using ReactAdminSample.Domain.Services;
using ReactAdminSample.Domain.Services.Impl;

namespace ReactAdminSample.Domain.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationDomain(this IServiceCollection services) => services
            .AddRepositories()
            .AddServices();

        private static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddScoped<IMakeRepository, MakeRepository>();

        private static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddScoped<IMakeService, MakeService>();
    }
}
