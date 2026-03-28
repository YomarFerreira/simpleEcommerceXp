using Application.Commands.Cliente;
using FluentValidation;

namespace Application.Validators.Cliente
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(150).WithMessage("Nome deve ter no máximo 150 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.")
                .MaximumLength(200).WithMessage("E-mail deve ter no máximo 200 caracteres.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("Telefone é obrigatório.")
                .MaximumLength(20).WithMessage("Telefone deve ter no máximo 20 caracteres.");

            RuleFor(x => x.TipoDocumento)
                .IsInEnum().WithMessage("Tipo de documento inválido.");

            RuleFor(x => x.Documento)
                .NotEmpty().WithMessage("Documento é obrigatório.")
                .MaximumLength(20).WithMessage("Documento deve ter no máximo 20 caracteres.");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("Senha é obrigatória.")
                .MinimumLength(6).WithMessage("Senha deve ter no mínimo 6 caracteres.");

            RuleFor(x => x.UsuarioCriacao)
                .NotEmpty().WithMessage("UsuarioCriacao é obrigatório.");
        }
    }
}
