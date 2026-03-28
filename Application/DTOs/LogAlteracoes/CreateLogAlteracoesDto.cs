namespace Application.DTOs.LogAlteracoes
{
    public class CreateLogAlteracoesDto
    {
        public string Entidade { get; set; } = string.Empty;
        public string ValorAnterior { get; set; } = string.Empty;
        public string ValorPosterior { get; set; } = string.Empty;
        public string UsuarioCriacao { get; set; } = string.Empty;
    }
}
