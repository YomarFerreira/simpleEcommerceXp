using System.Text.Json;
using Application.Commands.LogAlteracoes;
using Application.Commands.Pedido;
using Application.Handlers.LogAlteracoes;
using Domain.Properties;
using Infrastructure.Repository.Interface;

namespace Application.Handlers.Pedido
{
    public interface IUpdatePedidoHandler
    {
        Task<Domain.Entities.Pedido> Handle(UpdatePedidoCommand command);
    }

    public class UpdatePedidoHandler : IUpdatePedidoHandler
    {
        private readonly IPedidoRepository _repository;
        private readonly ICreateLogAlteracoesHandler _logHandler;

        public UpdatePedidoHandler(IPedidoRepository repository, ICreateLogAlteracoesHandler logHandler)
        {
            _repository = repository;
            _logHandler = logHandler;
        }

        public async Task<Domain.Entities.Pedido> Handle(UpdatePedidoCommand command)
        {
            var pedido = await _repository.GetById(command.Id)
                ?? throw new KeyNotFoundException($"Pedido {command.Id} não encontrado.");

            if (command.Desconto.HasValue && command.Desconto.Value >= pedido.ValorTotal)
                throw new InvalidOperationException("Desconto não pode ser maior ou igual ao ValorTotal do pedido.");

            if (command.NumeroParcelas.HasValue)
            {
                var tipoPagamentoEfetivo = command.TipoPagamento ?? pedido.TipoPagamento;
                var parcelas = command.NumeroParcelas.Value;

                if (!TipoPagamentoRegras.EhParcelavel(tipoPagamentoEfetivo) && parcelas != 1)
                    throw new InvalidOperationException($"{tipoPagamentoEfetivo} é pagamento à vista. NumeroParcelas deve ser 1.");

                if (TipoPagamentoRegras.EhParcelavel(tipoPagamentoEfetivo) && parcelas > TipoPagamentoRegras.MaxParcelas(tipoPagamentoEfetivo))
                    throw new InvalidOperationException($"{tipoPagamentoEfetivo} permite no máximo {TipoPagamentoRegras.MaxParcelas(tipoPagamentoEfetivo)} parcela(s).");
            }

            var valorAnterior = JsonSerializer.Serialize(pedido);
            pedido.Atualizar(command.Desconto, command.StatusEntrega,
                command.TipoPagamento, command.NumeroParcelas);
            await _repository.Update(pedido);

            await _logHandler.Handle(new CreateLogAlteracoesCommand
            {
                Entidade = "Pedido",
                ValorAnterior = valorAnterior,
                ValorPosterior = JsonSerializer.Serialize(pedido),
                UsuarioCriacao = pedido.UsuarioCriacao
            });

            return pedido;
        }
    }
}
