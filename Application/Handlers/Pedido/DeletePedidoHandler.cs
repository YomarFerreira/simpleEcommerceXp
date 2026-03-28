using Application.Commands.Pedido;
using Infrastructure.Repository.Interface;

namespace Application.Handlers.Pedido
{
    public interface IDeletePedidoHandler
    {
        Task Handle(DeletePedidoCommand command);
    }

    public class DeletePedidoHandler : IDeletePedidoHandler
    {
        private readonly IPedidoRepository _repository;

        public DeletePedidoHandler(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeletePedidoCommand command)
        {
            var pedido = await _repository.GetById(command.Id)
                ?? throw new KeyNotFoundException($"Pedido {command.Id} não encontrado.");

            // Regra de negócio: só pode cancelar antes da entrega (validada na entidade)
            pedido.Cancelar();
            await _repository.Update(pedido);
        }
    }
}
