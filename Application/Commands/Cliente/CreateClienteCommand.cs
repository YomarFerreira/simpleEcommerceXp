using Domain.Properties;

namespace Application.Commands.Cliente
{
    public class CreateClienteCommand
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public TipoDocumento TipoDocumento { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string UsuarioCriacao { get; set; } = string.Empty;
    }
}
