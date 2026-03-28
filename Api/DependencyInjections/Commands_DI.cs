using Application.Handlers.Cliente;
using Application.Handlers.Endereco;
using Application.Handlers.LogAlteracoes;
using Application.Handlers.Pedido;
using Application.Handlers.Produto;

namespace Api.DependencyInjections
{
    public static class CommandsDI
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            // Cliente
            services.AddScoped<ICreateClienteHandler, CreateClienteHandler>();
            services.AddScoped<IUpdateClienteHandler, UpdateClienteHandler>();
            services.AddScoped<IDeleteClienteHandler, DeleteClienteHandler>();
            services.AddScoped<IAlterarSenhaHandler, AlterarSenhaHandler>();

            // Endereço
            services.AddScoped<ICreateEnderecoHandler, CreateEnderecoHandler>();
            services.AddScoped<IUpdateEnderecoHandler, UpdateEnderecoHandler>();
            services.AddScoped<IDeleteEnderecoHandler, DeleteEnderecoHandler>();

            // Produto
            services.AddScoped<ICreateProdutoHandler, CreateProdutoHandler>();
            services.AddScoped<IUpdateProdutoHandler, UpdateProdutoHandler>();
            services.AddScoped<IDeleteProdutoHandler, DeleteProdutoHandler>();
            services.AddScoped<IAjustarEstoqueHandler, AjustarEstoqueHandler>();

            // Pedido
            services.AddScoped<ICreatePedidoHandler, CreatePedidoHandler>();
            services.AddScoped<IUpdatePedidoHandler, UpdatePedidoHandler>();
            services.AddScoped<IDeletePedidoHandler, DeletePedidoHandler>();

            // LogAlteracoes
            services.AddScoped<ICreateLogAlteracoesHandler, CreateLogAlteracoesHandler>();

            return services;
        }
    }
}
