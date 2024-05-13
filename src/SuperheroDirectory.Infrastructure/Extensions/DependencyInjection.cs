using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperheroDirectory.Application.Caching;
using SuperheroDirectory.Application.Clients.Abstractions;
using SuperheroDirectory.Domain.Repositories;
using SuperheroDirectory.Infrastructure.Caching;
using SuperheroDirectory.Infrastructure.Clients;
using SuperheroDirectory.Infrastructure.Configurations;
using SuperheroDirectory.Infrastructure.Data;
using SuperheroDirectory.Infrastructure.Repositories;

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
            services.AddScoped<ISuperheroRepository, SuperheroRepository>();
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("SuperheroDB"));

            return services;
        }
    }
}
