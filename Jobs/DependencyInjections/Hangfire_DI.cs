using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jobs.DependencyInjections
{
    public static class HangfireDI
    {
        public static IServiceCollection AddHangfireConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(config =>
                config.UsePostgreSqlStorage(options =>
                    options.UseNpgsqlConnection(configuration.GetConnectionString("Default"))));

            services.AddHangfireServer();

            return services;
        }
    }
}
