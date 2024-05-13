using SuperheroDirectory.API.Constants;
using System.Security.Claims;
using System.Threading.RateLimiting;

namespace SuperheroDirectory.API.Extensions
{
    public static class RateLimiterExtension
    {
        public static IServiceCollection AddToknBuckerRateLimiter(this IServiceCollection services)
        {
            services.AddRateLimiter(limiterOptions =>
            {
                limiterOptions.AddPolicy(ApiConstants.TokenBucketPolicy, context =>
                {
                    string userId = string.Empty;
                    if (context.User.Identity?.IsAuthenticated is true)
                    {
                        userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    }
                    return RateLimitPartition.GetTokenBucketLimiter(userId, _ => new TokenBucketRateLimiterOptions
                    {
                        TokenLimit = 10,
                        ReplenishmentPeriod = TimeSpan.FromSeconds(60),
                        TokensPerPeriod = 10
                    });

                });
            });

            return services;
        }
    }
}
