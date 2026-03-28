namespace Application.Commands.Cliente
{
    public class AlterarSenhaCommand
    {
        public int Id { get; set; }
        public string SenhaAtual { get; set; } = string.Empty;
        public string NovaSenha { get; set; } = string.Empty;
        public string ConfirmarNovaSenha { get; set; } = string.Empty;
    }
}
