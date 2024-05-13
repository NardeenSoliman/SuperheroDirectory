using Microsoft.OpenApi.Models;
using SuperheroDirectory.Domain.Models;
using SuperheroDirectory.Infrastructure.Data;
using Swashbuckle.AspNetCore.Filters;

namespace SuperheroDirectory.API.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwagger();
            services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<AppDbContext>();
            services.AddToknBuckerRateLimiter();
            services.AddVersioning();

            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            app.MapGroup("/identity").MapIdentityApi<User>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRateLimiter();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
