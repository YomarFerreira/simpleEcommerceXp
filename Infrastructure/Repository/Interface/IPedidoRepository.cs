using Domain.Entities;
using Domain.Properties;

namespace Infrastructure.Repository.Interface
{
    public interface IPedidoRepository
    {
        Task Add(Pedido pedido);
        Task Update(Pedido pedido);
        Task Delete(int id);
        Task<Pedido?> GetById(int id);
        Task<List<Pedido>> GetAll();
        Task<List<Pedido>> GetByPeriodo(DateTime dataInicial, DateTime dataFinal);
        Task<List<Pedido>> GetByClienteId(int clienteId);
        Task<List<Pedido>> GetByProdutoId(int produtoId);
        Task<List<Pedido>> GetByStatusEntrega(StatusEntrega statusEntrega);
    }
}
