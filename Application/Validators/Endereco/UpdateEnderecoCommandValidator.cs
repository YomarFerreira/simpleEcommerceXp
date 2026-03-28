using Application.Commands.Endereco;
using FluentValidation;

namespace Application.Validators.Endereco
{
    public class UpdateEnderecoCommandValidator : AbstractValidator<UpdateEnderecoCommand>
    {
        private static readonly HashSet<string> _ufsValidas = new(StringComparer.OrdinalIgnoreCase)
        {
            "AC","AL","AP","AM","BA","CE","DF","ES","GO","MA",
            "MT","MS","MG","PA","PB","PR","PE","PI","RJ","RN",
            "RS","RO","RR","SC","SP","SE","TO"
        };

        public UpdateEnderecoCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id inválido.");

            RuleFor(x => x.Tipo)
                .NotEmpty().WithMessage("Tipo de endereço é obrigatório.")
                .MaximumLength(50).WithMessage("Tipo deve ter no máximo 50 caracteres.");

            RuleFor(x => x.Logradouro)
                .NotEmpty().WithMessage("Logradouro é obrigatório.")
                .MaximumLength(200).WithMessage("Logradouro deve ter no máximo 200 caracteres.");

            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage("Número é obrigatório.")
                .MaximumLength(10).WithMessage("Número deve ter no máximo 10 caracteres.");

            RuleFor(x => x.Bairro)
                .NotEmpty().WithMessage("Bairro é obrigatório.")
                .MaximumLength(100).WithMessage("Bairro deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("Cidade é obrigatória.")
                .MaximumLength(100).WithMessage("Cidade deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Uf)
                .NotEmpty().WithMessage("UF é obrigatória.")
                .Must(uf => _ufsValidas.Contains(uf)).WithMessage("UF inválida. Informe a sigla de um estado brasileiro (ex: SP, RJ, MG).");
        }
    }
}
