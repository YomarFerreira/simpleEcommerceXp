using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Properties;
using Infrastructure.Repository.Interface;

namespace Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;

        public PedidoService(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Pedido?> ObterPorId(int id) => await _repository.GetById(id);

        public async Task<List<Pedido>> ObterTodos() => await _repository.GetAll();

        public async Task<List<Pedido>> ObterPorPeriodo(DateTime dataInicial, DateTime dataFinal) =>
            await _repository.GetByPeriodo(dataInicial.ToUniversalTime(), dataFinal.ToUniversalTime());

        public async Task<List<Pedido>> ObterPorClienteId(int clienteId) =>
            await _repository.GetByClienteId(clienteId);

        public async Task<List<Pedido>> ObterPorProdutoId(int produtoId) =>
            await _repository.GetByProdutoId(produtoId);

        public async Task<List<Pedido>> ObterPorStatusEntrega(StatusEntrega statusEntrega) =>
            await _repository.GetByStatusEntrega(statusEntrega);
    }
}
