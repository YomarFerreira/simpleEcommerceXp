using Api.DependencyInjections;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
    ?? builder.Configuration.GetConnectionString("Default");

if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("Api - Connection string não configurada.");

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
