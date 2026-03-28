using Application.Commands.LogAlteracoes;
using FluentValidation;

namespace Application.Validators.LogAlteracoes
{
    public class CreateLogAlteracoesCommandValidator : AbstractValidator<CreateLogAlteracoesCommand>
    {
        public CreateLogAlteracoesCommandValidator()
        {
            RuleFor(x => x.Entidade)
                .NotEmpty().WithMessage("Entidade é obrigatória.")
                .MaximumLength(100).WithMessage("Entidade deve ter no máximo 100 caracteres.");

            RuleFor(x => x.ValorAnterior)
                .NotEmpty().WithMessage("ValorAnterior é obrigatório.");

            RuleFor(x => x.ValorPosterior)
                .NotEmpty().WithMessage("ValorPosterior é obrigatório.");

            RuleFor(x => x.UsuarioCriacao)
                .NotEmpty().WithMessage("UsuarioCriacao é obrigatório.");
        }
    }
}
