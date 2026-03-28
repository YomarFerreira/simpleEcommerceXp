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

var emailOverrides = new Dictionary<string, string?>();
var emailSmtp        = Environment.GetEnvironmentVariable("EMAIL_SMTP");
var emailPorta       = Environment.GetEnvironmentVariable("EMAIL_PORTA");
var emailRemetente   = Environment.GetEnvironmentVariable("EMAIL_REMETENTE");
var emailSenha       = Environment.GetEnvironmentVariable("EMAIL_SENHA");
var emailDestinatario= Environment.GetEnvironmentVariable("EMAIL_DESTINATARIO");
var emailUrlBase     = Environment.GetEnvironmentVariable("EMAIL_URLBASE");

if (emailSmtp        != null) emailOverrides["Email:Smtp"]        = emailSmtp;
if (emailPorta       != null) emailOverrides["Email:Porta"]       = emailPorta;
if (emailRemetente   != null) emailOverrides["Email:Remetente"]   = emailRemetente;
if (emailSenha       != null) emailOverrides["Email:Senha"]       = emailSenha;
if (emailDestinatario!= null) emailOverrides["Email:Destinatario"]= emailDestinatario;
if (emailUrlBase     != null) emailOverrides["Email:UrlBase"]     = emailUrlBase;

if (emailOverrides.Count > 0)
    builder.Configuration.AddInMemoryCollection(emailOverrides);

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
