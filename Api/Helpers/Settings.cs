using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json;

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

        public static void AddServices(this IServiceCollection services)
        {
            Injector.RegisterServices(services);
        }

        public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("cors",
                    builder =>
                    {
                        if (env.IsProduction())
                            builder
                                .WithOrigins(configuration.GetValue<string>("cors").Split(','))
                                .SetPreflightMaxAge(System.TimeSpan.FromDays(1))
                                .AllowAnyMethod()
                                .AllowCredentials()
                                .AllowAnyHeader();
                        else
                            builder
                                .SetIsOriginAllowed((host) => true)
                                .SetPreflightMaxAge(System.TimeSpan.FromDays(1))
                                .AllowAnyMethod()
                                .AllowCredentials()
                                .AllowAnyHeader();
                    });
            });
            return services;
        }
    }
}
