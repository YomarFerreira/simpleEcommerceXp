using Infrastructure.Repository;
using Infrastructure.Repository.Interface;

namespace Api.DependencyInjections
{
    public static class RepositoriesDI
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<ILogAlteracoesRepository, LogAlteracoesRepository>();
            return services;
        }
    }
}
