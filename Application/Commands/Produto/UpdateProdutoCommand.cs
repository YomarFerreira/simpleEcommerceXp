namespace Application.Commands.Produto
{
    public class UpdateProdutoCommand
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
    }
}
