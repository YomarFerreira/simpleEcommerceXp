using Domain.Entities;
using Domain.Properties;

namespace Application.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<Pedido?> ObterPorId(int id);
        Task<List<Pedido>> ObterTodos();
        Task<List<Pedido>> ObterPorPeriodo(DateTime dataInicial, DateTime dataFinal);
        Task<List<Pedido>> ObterPorClienteId(int clienteId);
        Task<List<Pedido>> ObterPorProdutoId(int produtoId);
        Task<List<Pedido>> ObterPorStatusEntrega(StatusEntrega statusEntrega);
    }
}
