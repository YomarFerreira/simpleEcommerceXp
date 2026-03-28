using Hangfire;
using Hangfire.PostgreSql;
using Infrastructure.Data;
using Jobs.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jobs.DependencyInjections
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddJobsDependencies(this IServiceCollection services, IConfiguration configuration, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddHangfire(config =>
                config.UsePostgreSqlStorage(options =>
                    options.UseNpgsqlConnection(connectionString)));

            services.AddHangfireServer();

            services.AddSingleton<IEmailHabilitadoService, EmailHabilitadoService>();
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
