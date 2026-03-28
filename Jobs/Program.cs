using Hangfire;
using Jobs.DependencyInjections;
using Jobs.Jobs;
using Jobs.Services;

SQLitePCL.Batteries.Init();

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
    ?? builder.Configuration.GetConnectionString("Default");

Console.WriteLine($"Jobs - DATABASE_URL: {(Environment.GetEnvironmentVariable("DATABASE_URL") is null ? "NOT SET (usando appsettings)" : "OK")}");

if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("Jobs - Connection string não configurada.");

builder.Services.AddJobsDependencies(builder.Configuration, connectionString);

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

var jobOptions = new RecurringJobOptions
{
    MisfireHandling = MisfireHandlingMode.Ignorable
};

RecurringJob.AddOrUpdate<RelatorioVendasJob>(
    "relatorio-vendas",
    job => job.Executar(),
    "0 */6 * * *",
    jobOptions);

RecurringJob.AddOrUpdate<RelatorioLogsJob>(
    "relatorio-logs",
    job => job.Executar(),
    "0 0 * * *",
    jobOptions);

app.Run();
