using Application.Commands.Produto;
using Domain.Properties;
using FluentValidation;

namespace Application.Validators.Produto
{
    public class AjustarEstoqueCommandValidator : AbstractValidator<AjustarEstoqueCommand>
    {
        public AjustarEstoqueCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id inválido.");

            RuleFor(x => x.Operacao)
                .IsInEnum().WithMessage("Operação inválida. Use 1 (Debito) ou 2 (Credito).");

            RuleFor(x => x.Quantidade)
                .GreaterThan(0).WithMessage("Quantidade deve ser maior que zero.");

            RuleFor(x => x.NovoValor)
                .GreaterThan(0).WithMessage("NovoValor deve ser maior que zero.")
                .When(x => x.NovoValor.HasValue);

            RuleFor(x => x.NovoValor)
                .NotNull().WithMessage("NovoValor é obrigatório quando CalcularMediaValor é verdadeiro.")
                .When(x => x.CalcularMediaValor);
        }
    }
}
