using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Api.Helpers
{
    public static class Settings
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration, bool isDev = true)
        {
            services.AddDbContextPool<PhotographerContext>(options =>
            {
                options
                    .UseSqlServer(configuration.GetConnectionString(nameof(PhotographerContext)), x => x.EnableRetryOnFailure())
                    .ConfigureWarnings(x => x.Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning))
                    .EnableSensitiveDataLogging(isDev)
                    .EnableDetailedErrors(isDev)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            return services;
        }
    }
}
