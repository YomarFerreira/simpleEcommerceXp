namespace Application.Commands.Produto
{
    public class CreateProdutoCommand
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public int Estoque { get; set; }
        public string UsuarioCriacao { get; set; } = string.Empty;
    }
}
