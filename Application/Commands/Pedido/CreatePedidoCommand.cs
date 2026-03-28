using Domain.Properties;

namespace Application.Commands.Pedido
{
    public class CreatePedidoCommand
    {
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public int NumeroParcelas { get; set; }
        public string UsuarioCriacao { get; set; } = string.Empty;
    }
}
