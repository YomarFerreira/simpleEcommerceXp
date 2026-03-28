using Application.Services;
using Application.Services.Interfaces;

namespace Api.DependencyInjections
{
    public static class ServicesDI
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<ILogAlteracoesService, LogAlteracoesService>();
            return services;
        }
    }
}
