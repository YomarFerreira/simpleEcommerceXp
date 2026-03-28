namespace Application.DTOs.Pedido
{
    public class CreatePedidoDto
    {
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; }
        public string UsuarioCriacao { get; set; } = string.Empty;
    }
}
