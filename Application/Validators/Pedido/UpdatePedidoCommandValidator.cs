using Application.Commands.Pedido;
using Domain.Properties;
using FluentValidation;

namespace Application.Validators.Pedido
{
    public class UpdatePedidoCommandValidator : AbstractValidator<UpdatePedidoCommand>
    {
        public UpdatePedidoCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id inválido.");

            RuleFor(x => x)
                .Must(x => x.Desconto.HasValue || x.StatusEntrega.HasValue || x.TipoPagamento.HasValue || x.NumeroParcelas.HasValue)
                .WithMessage("Informe ao menos um campo para atualizar.");

            RuleFor(x => x.Desconto)
                .GreaterThanOrEqualTo(0).WithMessage("Desconto não pode ser negativo.")
                .When(x => x.Desconto.HasValue);

            RuleFor(x => x.StatusEntrega)
                .IsInEnum().WithMessage("StatusEntrega inválida.")
                .When(x => x.StatusEntrega.HasValue);

            RuleFor(x => x.TipoPagamento)
                .IsInEnum().WithMessage("Tipo de pagamento inválido.")
                .When(x => x.TipoPagamento.HasValue);

            RuleFor(x => x.NumeroParcelas)
                .GreaterThan(0).WithMessage("NumeroParcelas deve ser maior que zero.")
                .When(x => x.NumeroParcelas.HasValue);

            RuleFor(x => x.NumeroParcelas)
                .Must((cmd, parcelas) =>
                {
                    var tipo = cmd.TipoPagamento!.Value;
                    return TipoPagamentoRegras.EhParcelavel(tipo)
                        ? parcelas!.Value <= TipoPagamentoRegras.MaxParcelas(tipo)
                        : parcelas!.Value == 1;
                })
                .WithMessage(cmd =>
                {
                    var tipo = cmd.TipoPagamento!.Value;
                    return TipoPagamentoRegras.EhParcelavel(tipo)
                        ? $"{tipo} permite no máximo {TipoPagamentoRegras.MaxParcelas(tipo)} parcela(s)."
                        : $"{tipo} é pagamento à vista. NumeroParcelas deve ser 1.";
                })
                .When(x => x.TipoPagamento.HasValue && x.NumeroParcelas.HasValue);
        }
    }
}
