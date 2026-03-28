using Hangfire;
using Jobs.DependencyInjections;
using Jobs.Jobs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddHangfireConfig(builder.Configuration);

builder.Services.AddScoped<RelatorioVendasJob>();
builder.Services.AddScoped<RelatorioLogsJob>();

var app = builder.Build();

app.UseHangfireDashboard("/hangfire");

RecurringJob.AddOrUpdate<RelatorioVendasJob>(
    "relatorio-vendas",
    job => job.Executar(),
    Cron.Hourly());

RecurringJob.AddOrUpdate<RelatorioLogsJob>(
    "relatorio-logs",
    job => job.Executar(),
    Cron.Daily());

app.Run();
