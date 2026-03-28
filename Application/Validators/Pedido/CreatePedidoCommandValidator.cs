using Application.Commands.Pedido;
using Domain.Properties;
using FluentValidation;

namespace Application.Validators.Pedido
{
    public class CreatePedidoCommandValidator : AbstractValidator<CreatePedidoCommand>
    {
        public CreatePedidoCommandValidator()
        {
            RuleFor(x => x.IdCliente)
                .GreaterThan(0).WithMessage("IdCliente inválido.");

            RuleFor(x => x.IdProduto)
                .GreaterThan(0).WithMessage("IdProduto inválido.");

            RuleFor(x => x.ValorTotal)
                .GreaterThan(0).WithMessage("ValorTotal deve ser maior que zero.");

            RuleFor(x => x.Desconto)
                .GreaterThanOrEqualTo(0).WithMessage("Desconto não pode ser negativo.")
                .Must((cmd, desconto) => desconto < cmd.ValorTotal)
                    .WithMessage("Desconto não pode ser maior ou igual ao ValorTotal.");

            RuleFor(x => x.TipoPagamento)
                .IsInEnum().WithMessage("Tipo de pagamento inválido.");

            RuleFor(x => x.NumeroParcelas)
                .GreaterThan(0).WithMessage("NumeroParcelas deve ser maior que zero.")
                .Must((cmd, parcelas) =>
                {
                    return TipoPagamentoRegras.EhParcelavel(cmd.TipoPagamento)
                        ? parcelas <= TipoPagamentoRegras.MaxParcelas(cmd.TipoPagamento)
                        : parcelas == 1;
                })
                .WithMessage(cmd =>
                {
                    return TipoPagamentoRegras.EhParcelavel(cmd.TipoPagamento)
                        ? $"{cmd.TipoPagamento} permite no máximo {TipoPagamentoRegras.MaxParcelas(cmd.TipoPagamento)} parcela(s)."
                        : $"{cmd.TipoPagamento} é pagamento à vista. NumeroParcelas deve ser 1.";
                });

            RuleFor(x => x.UsuarioCriacao)
                .NotEmpty().WithMessage("UsuarioCriacao é obrigatório.");
        }
    }
}
