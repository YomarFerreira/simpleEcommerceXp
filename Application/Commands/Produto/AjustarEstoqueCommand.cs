using Domain.Properties;

namespace Application.Commands.Produto
{
    public class AjustarEstoqueCommand
    {
        public int Id { get; set; }
        public TipoAjusteEstoque Operacao { get; set; }
        public int Quantidade { get; set; }
        public decimal? NovoValor { get; set; }
        public bool CalcularMediaValor { get; set; }
    }
}
