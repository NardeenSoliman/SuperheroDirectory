using Microsoft.Extensions.DependencyInjection;
using SuperheroDirectory.Application.Services;
using SuperheroDirectory.Application.Services.Abstractions;

namespace SuperheroDirectory.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISuperheroService, SuperheroService>();
            return services;
        }
    }
}
