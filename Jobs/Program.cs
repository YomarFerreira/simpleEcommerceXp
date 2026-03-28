using Hangfire;
using Jobs.DependencyInjections;
using Jobs.Jobs;
using Jobs.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJobsDependencies(builder.Configuration);

builder.Services.AddScoped<RelatorioVendasJob>();
builder.Services.AddScoped<RelatorioLogsJob>();

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseHangfireDashboard("/hangfire");

app.MapHealthChecks("/health");

app.MapGet("/email/desativar", (IEmailHabilitadoService svc) =>
{
    svc.Desativar();
    return Results.Ok("Envio de e-mails desativado. Acesse /email/ativar para reativar.");
});

app.MapGet("/email/ativar", (IEmailHabilitadoService svc) =>
{
    svc.Ativar();
    return Results.Ok("Envio de e-mails ativado.");
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
