namespace Application.DTOs.Pedido
{
    public class UpdatePedidoDto
    {
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; }
    }
}
