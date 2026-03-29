using Application.Commands.Produto;
using Application.Handlers.Produto;
using Domain.Properties;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    [Tags("Produtos")]
    [Produces("application/json")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;
        private readonly ICreateProdutoHandler _createHandler;
        private readonly IUpdateProdutoHandler _updateHandler;
        private readonly IDeleteProdutoHandler _deleteHandler;
        private readonly IAjustarEstoqueHandler _ajustarEstoqueHandler;

        public ProdutoController(
            IProdutoService service,
            ICreateProdutoHandler createHandler,
            IUpdateProdutoHandler updateHandler,
            IDeleteProdutoHandler deleteHandler,
            IAjustarEstoqueHandler ajustarEstoqueHandler)
        {
            _service = service;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
            _ajustarEstoqueHandler = ajustarEstoqueHandler;
        }

        [HttpGet("total")]
        [EndpointSummary("Quantidade de produtos cadastrados")]
        [EndpointDescription("Retorna o total de produtos. Filtre por status: Ativo=1, Inativo=2. Sem filtro retorna todos.")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTotalProdutos([FromQuery] Status? status = null)
        {
            var total = await _service.ObterTotal(status);
            return Ok(new Dictionary<string, object> { ["total de produtos"] = total });
        }

        [HttpGet]
        [EndpointSummary("Listar todos os produtos")]
        [EndpointDescription("Retorna a lista completa de produtos cadastrados no sistema.")]
        [ProducesResponseType(typeof(IEnumerable<Produto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _service.ObterTodos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        [EndpointSummary("Buscar produto por ID")]
        [EndpointDescription("Retorna os dados de um produto específico pelo seu identificador.")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _service.ObterPorId(id);
            return produto is null ? NotFound() : Ok(produto);
        }

        [HttpGet("nome")]
        [EndpointSummary("Buscar produtos por parte do nome")]
        [EndpointDescription("Retorna todos os produtos cujo título contenha o trecho informado. A busca é case-insensitive.")]
        [ProducesResponseType(typeof(IEnumerable<Produto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByNome([FromQuery] string nome)
        {
            var produtos = await _service.ObterPorNome(nome);
            return Ok(produtos);
        }

        [HttpGet("periodo")]
        [EndpointSummary("Buscar produtos por período de cadastro")]
        [EndpointDescription("Retorna todos os produtos cuja DataCriacao esteja dentro do intervalo informado (inclusive). Formato: yyyy-MM-ddTHH:mm:ssZ.")]
        [ProducesResponseType(typeof(IEnumerable<Produto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByPeriodo([FromQuery] DateTime dataInicial, [FromQuery] DateTime dataFinal)
        {
            var produtos = await _service.ObterPorPeriodo(dataInicial, dataFinal);
            return Ok(produtos);
        }

        [HttpPost]
        [EndpointSummary("Cadastrar produto")]
        [EndpointDescription("Cria um novo produto com título, descrição e valor.")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateProdutoCommand command)
        {
            var produto = await _createHandler.Handle(command);
            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        [HttpPut]
        [EndpointSummary("Editar produto")]
        [EndpointDescription("Atualiza completamente os dados de um produto existente (título, descrição e valor).")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] UpdateProdutoCommand command)
        {
            var produto = await _updateHandler.Handle(command);
            return Ok(produto);
        }

        [HttpPatch("{id}/estoque")]
        [EndpointSummary("Ajustar estoque do produto")]
        [EndpointDescription("Debita ou credita quantidade no estoque. Permite atualizar o valor e calcular média ponderada entre estoque atual e o novo lote.")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AjustarEstoque(int id, [FromBody] AjustarEstoqueCommand command)
        {
            command.Id = id;
            try
            {
                var produto = await _ajustarEstoqueHandler.Handle(command);
                return Ok(produto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { erro = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Inativar produto")]
        [EndpointDescription("Realiza soft delete do produto, alterando seu status para Inativo.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteHandler.Handle(new DeleteProdutoCommand { Id = id });
            return NoContent();
        }
    }
}
