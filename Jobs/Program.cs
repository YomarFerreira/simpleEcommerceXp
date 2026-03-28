using Hangfire;
using Jobs.DependencyInjections;
using Jobs.Jobs;

var builder = WebApplication.CreateBuilder(args);

// For the Render
builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddHangfireConfig(builder.Configuration);

builder.Services.AddScoped<RelatorioVendasJob>();
builder.Services.AddScoped<RelatorioLogsJob>();

var app = builder.Build();

app.MapGet("/", () => "Jobs running");

app.MapHangfireDashboard("/hangfire");


// JOBS
RecurringJob.AddOrUpdate<RelatorioVendasJob>(
    "relatorio-vendas",
    job => job.Executar(),
    "0 */6 * * *");

RecurringJob.AddOrUpdate<RelatorioLogsJob>(
    "relatorio-logs",
    job => job.Executar(),
    "0 0 * * *");

app.Run();