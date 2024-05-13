using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperheroDirectory.Application.Caching;
using SuperheroDirectory.Application.Clients.Abstractions;
using SuperheroDirectory.Infrastructure.Caching;
using SuperheroDirectory.Infrastructure.Clients;
using SuperheroDirectory.Infrastructure.Configurations;

namespace SuperheroDirectory.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            SuperheroApiConfig config = configuration.GetSection("SuperheroApiConfig").Get<SuperheroApiConfig>();
            services.AddHttpClient<ISuperheroClient, SuperheroClient>(x => x.BaseAddress = new Uri($"{config.BaseURL}/{config.AccessToken}/"));

            services.AddMemoryCache();
            services.AddSingleton<ISystemCache, SystemCache>();
            return services;
        }
    }
}
