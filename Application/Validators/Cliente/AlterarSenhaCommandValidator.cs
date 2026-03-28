using Application.Commands.Cliente;
using FluentValidation;

namespace Application.Validators.Cliente
{
    public class AlterarSenhaCommandValidator : AbstractValidator<AlterarSenhaCommand>
    {
        public AlterarSenhaCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id inválido.");

            RuleFor(x => x.SenhaAtual)
                .NotEmpty().WithMessage("Senha atual é obrigatória.");

            RuleFor(x => x.NovaSenha)
                .NotEmpty().WithMessage("Nova senha é obrigatória.")
                .MinimumLength(6).WithMessage("Nova senha deve ter ao menos 6 caracteres.");

            RuleFor(x => x.ConfirmarNovaSenha)
                .Equal(x => x.NovaSenha).WithMessage("Confirmação de senha não confere com a nova senha.");
        }
    }
}
