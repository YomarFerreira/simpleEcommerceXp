using Application.Commands.Pedido;
using Infrastructure.Repository.Interface;

namespace Application.Handlers.Pedido
{
    public interface ICreatePedidoHandler
    {
        Task<Domain.Entities.Pedido> Handle(CreatePedidoCommand command);
    }

    public class CreatePedidoHandler : ICreatePedidoHandler
    {
        private readonly IPedidoRepository _repository;

        public CreatePedidoHandler(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.Pedido> Handle(CreatePedidoCommand command)
        {
            var pedido = new Domain.Entities.Pedido(
                command.IdCliente, command.IdProduto,
                command.ValorTotal, command.Desconto,
                command.TipoPagamento, command.NumeroParcelas,
                command.UsuarioCriacao);

            await _repository.Add(pedido);
            return pedido;
        }
    }
}
