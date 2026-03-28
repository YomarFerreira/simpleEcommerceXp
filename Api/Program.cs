using Api.DependencyInjections;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
    ?? builder.Configuration.GetConnectionString("Default");

Console.WriteLine($"Api - DATABASE_URL: {(Environment.GetEnvironmentVariable("DATABASE_URL") is null ? "NOT SET (usando appsettings)" : "OK")}");

if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("Api - Connection string não configurada.");

// Testa conexão antes de iniciar
try
{
    using var conn = new NpgsqlConnection(connectionString);
    conn.Open();
    using var cmd = new NpgsqlCommand("SELECT 1", conn);
    cmd.ExecuteScalar();
    Console.WriteLine("Api - PostgreSQL connection + query: OK");
}
catch (Exception ex)
{
    Console.WriteLine($"Api - PostgreSQL connection FAILED: {ex.Message}");
}

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddCommands();
builder.Services.AddValidations();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapControllers();

app.Run();
