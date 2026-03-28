using Domain.Properties;

namespace Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public int IdCliente { get; private set; }
        public int IdProduto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorFinal { get; private set; }
        public StatusEntrega StatusEntrega { get; set; }
        public TipoPagamento TipoPagamento { get; private set; }
        public int NumeroParcelas { get; private set; }

        public Pedido() { }

        public Pedido(int idCliente, int idProduto, decimal valorTotal, decimal desconto,
            TipoPagamento tipoPagamento, int numeroParcelas, string usuarioCriacao)
        {
            IdCliente = idCliente;
            IdProduto = idProduto;
            ValorTotal = valorTotal;
            Desconto = desconto;
            ValorFinal = valorTotal - desconto;
            TipoPagamento = tipoPagamento;
            NumeroParcelas = numeroParcelas;
            StatusEntrega = StatusEntrega.PedidoRecebido;
            Status = Status.Ativo;
            DataCriacao = DateTime.UtcNow;
            UsuarioCriacao = usuarioCriacao;
        }

        public void Atualizar(decimal? desconto, StatusEntrega? statusEntrega,
            TipoPagamento? tipoPagamento, int? numeroParcelas)
        {
            if (StatusEntrega == StatusEntrega.Entregue)
                throw new InvalidOperationException("Pedido já entregue não pode ser alterado.");

            if (desconto.HasValue)
            {
                Desconto = desconto.Value;
                ValorFinal = ValorTotal - Desconto;
            }
            if (statusEntrega.HasValue)
                StatusEntrega = statusEntrega.Value;
            if (tipoPagamento.HasValue)
                TipoPagamento = tipoPagamento.Value;
            if (numeroParcelas.HasValue)
                NumeroParcelas = numeroParcelas.Value;
        }

        public void Cancelar()
        {
            if (StatusEntrega == StatusEntrega.Entregue)
                throw new InvalidOperationException("Pedido já entregue não pode ser cancelado.");

            Status = Status.Cancelado;
        }
    }
}
