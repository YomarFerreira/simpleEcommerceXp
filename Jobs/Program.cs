using Hangfire;
using Jobs.DependencyInjections;
using Jobs.Jobs;

var builder = WebApplication.CreateBuilder(args);

// obrigatório para Render
builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddRouting();

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddHangfireConfig(builder.Configuration);

builder.Services.AddScoped<RelatorioVendasJob>();
builder.Services.AddScoped<RelatorioLogsJob>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Jobs running");
    });

    endpoints.MapHangfireDashboard("/hangfire");
});

RecurringJob.AddOrUpdate<RelatorioVendasJob>(
    "relatorio-vendas",
    job => job.Executar(),
    "0 */6 * * *");

RecurringJob.AddOrUpdate<RelatorioLogsJob>(
    "relatorio-logs",
    job => job.Executar(),
    "0 0 * * *");

app.Run();