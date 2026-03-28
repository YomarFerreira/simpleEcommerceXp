namespace Application.DTOs.Produto
{
    public class CreateProdutoDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string UsuarioCriacao { get; set; } = string.Empty;
    }
}
