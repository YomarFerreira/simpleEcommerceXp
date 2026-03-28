using Application.Commands.Produto;
using FluentValidation;

namespace Application.Validators.Produto
{
    public class CreateProdutoCommandValidator : AbstractValidator<CreateProdutoCommand>
    {
        public CreateProdutoCommandValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("Título é obrigatório.")
                .MaximumLength(200).WithMessage("Título deve ter no máximo 200 caracteres.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("Descrição é obrigatória.")
                .MaximumLength(1000).WithMessage("Descrição deve ter no máximo 1000 caracteres.");

            RuleFor(x => x.Valor)
                .GreaterThan(0).WithMessage("Valor deve ser maior que zero.");

            RuleFor(x => x.Estoque)
                .GreaterThanOrEqualTo(0).WithMessage("Estoque não pode ser negativo.");

            RuleFor(x => x.UsuarioCriacao)
                .NotEmpty().WithMessage("UsuarioCriacao é obrigatório.");
        }
    }
}
