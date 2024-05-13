using Microsoft.Extensions.DependencyInjection;

namespace SuperheroDirectory.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
