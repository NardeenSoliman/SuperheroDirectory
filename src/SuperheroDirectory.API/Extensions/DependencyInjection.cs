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
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<AppDbContext>();

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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
