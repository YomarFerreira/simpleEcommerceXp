using Domain.Properties;

namespace Application.Commands.Pedido
{
    public class UpdatePedidoCommand
    {
        public int Id { get; set; }
        public decimal? Desconto { get; set; }
        public StatusEntrega? StatusEntrega { get; set; }
        public TipoPagamento? TipoPagamento { get; set; }
        public int? NumeroParcelas { get; set; }
    }
}
