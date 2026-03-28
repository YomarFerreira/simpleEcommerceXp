namespace Domain.Entities
{
    public class LogAlteracoes : BaseEntity
    {
        public string Entidade { get; set; } = string.Empty;
        public string ValorAnterior { get; set; } = string.Empty;
        public string ValorPosterior { get; set; } = string.Empty;

        public LogAlteracoes() { }

        public LogAlteracoes(string entidade, string valorAnterior, string valorPosterior, string usuarioCriacao)
        {
            Entidade = entidade;
            ValorAnterior = valorAnterior;
            ValorPosterior = valorPosterior;
            DataCriacao = DateTime.UtcNow;
            UsuarioCriacao = usuarioCriacao;
        }
    }
}
