using Application.Commands.Pedido;
using Application.Handlers.Pedido;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Properties;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    [Tags("Pedidos")]
    [Produces("application/json")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _service;
        private readonly ICreatePedidoHandler _createHandler;
        private readonly IUpdatePedidoHandler _updateHandler;
        private readonly IDeletePedidoHandler _deleteHandler;

        public PedidoController(
            IPedidoService service,
            ICreatePedidoHandler createHandler,
            IUpdatePedidoHandler updateHandler,
            IDeletePedidoHandler deleteHandler)
        {
            _service = service;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
        }

        [HttpGet("total")]
        [EndpointSummary("Quantidade de pedidos")]
        [EndpointDescription("Retorna o total de pedidos com filtros opcionais. Status: Ativo=1, Inativo=2, Cancelado=3. StatusEntrega: PedidoRecebido=1, EmSeparacao=2, EmRotaEntrega=3, Entregue=4. Valor Mínimo e Valor Máximo")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTotalPedidos(
            [FromQuery] Status? status = null,
            [FromQuery] StatusEntrega? statusEntrega = null,
            [FromQuery] decimal? valorMinimo = null,
            [FromQuery] decimal? valorMaximo = null)
        {
            var total = await _service.ObterTotal(status, statusEntrega, valorMinimo, valorMaximo);
            return Ok(new Dictionary<string, object> { ["total de pedidos"] = total });
        }

        [HttpGet]
        [EndpointSummary("Listar todos os pedidos")]
        [EndpointDescription("Retorna a lista completa de pedidos cadastrados no sistema.")]
        [ProducesResponseType(typeof(IEnumerable<Pedido>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _service.ObterTodos();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        [EndpointSummary("Buscar pedido por ID")]
        [EndpointDescription("Retorna os dados de um pedido específico pelo seu identificador.")]
        [ProducesResponseType(typeof(Pedido), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _service.ObterPorId(id);
            return pedido is null ? NotFound() : Ok(pedido);
        }

        [HttpGet("periodo")]
        [EndpointSummary("Buscar pedidos por período")]
        [EndpointDescription("Retorna todos os pedidos cuja DataCriacao esteja dentro do intervalo informado (inclusive). Formato: yyyy-MM-ddTHH:mm:ssZ.")]
        [ProducesResponseType(typeof(IEnumerable<Pedido>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByPeriodo([FromQuery] DateTime dataInicial, [FromQuery] DateTime dataFinal)
        {
            var pedidos = await _service.ObterPorPeriodo(dataInicial, dataFinal);
            return Ok(pedidos);
        }

        [HttpGet("cliente/{clienteId}")]
        [EndpointSummary("Buscar pedidos por ClienteId")]
        [EndpointDescription("Retorna todos os pedidos vinculados a um cliente específico.")]
        [ProducesResponseType(typeof(IEnumerable<Pedido>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByClienteId(int clienteId)
        {
            var pedidos = await _service.ObterPorClienteId(clienteId);
            return Ok(pedidos);
        }

        [HttpGet("produto/{produtoId}")]
        [EndpointSummary("Buscar pedidos por ProdutoId")]
        [EndpointDescription("Retorna todos os pedidos que contêm um produto específico.")]
        [ProducesResponseType(typeof(IEnumerable<Pedido>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByProdutoId(int produtoId)
        {
            var pedidos = await _service.ObterPorProdutoId(produtoId);
            return Ok(pedidos);
        }

        [HttpGet("status/{statusEntrega}")]
        [EndpointSummary("Buscar pedidos por StatusEntrega")]
        [EndpointDescription("Retorna todos os pedidos com o status de entrega informado. Valores: PedidoRecebido=1, EmSeparacao=2, EmRotaEntrega=3, Entregue=4.")]
        [ProducesResponseType(typeof(IEnumerable<Pedido>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByStatusEntrega(StatusEntrega statusEntrega)
        {
            var pedidos = await _service.ObterPorStatusEntrega(statusEntrega);
            return Ok(pedidos);
        }

        [HttpPost]
        [EndpointSummary("Criar pedido")]
        [EndpointDescription("Cria um novo pedido. O ValorFinal é calculado automaticamente (ValorTotal - Desconto). O status inicial é 'PedidoRecebido'.")]
        [ProducesResponseType(typeof(Pedido), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreatePedidoCommand command)
        {
            var pedido = await _createHandler.Handle(command);
            return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
        }

        [HttpPatch("{id}")]
        [EndpointSummary("Editar pedido")]
        [EndpointDescription("Atualiza parcialmente um pedido. Campos disponíveis: Desconto (recalcula ValorFinal), StatusEntrega, TipoPagamento, NumeroParcelas. Envie apenas os campos que deseja alterar. **Regra:** só é permitido editar pedidos com StatusEntrega diferente de 'Entregue'.")]
        [ProducesResponseType(typeof(Pedido), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Patch(int id, [FromBody] UpdatePedidoCommand command)
        {
            command.Id = id;
            try
            {
                var pedido = await _updateHandler.Handle(command);
                return Ok(pedido);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Cancelar pedido")]
        [EndpointDescription("Cancela um pedido alterando seu status para 'Cancelado'. **Regra:** só é permitido cancelar pedidos com StatusEntrega diferente de 'Entregue'.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _deleteHandler.Handle(new DeletePedidoCommand { Id = id });
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
