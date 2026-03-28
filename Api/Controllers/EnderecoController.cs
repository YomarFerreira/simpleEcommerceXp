using Application.Commands.Endereco;
using Application.Handlers.Endereco;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/enderecos")]
    [Tags("Endereços")]
    [Produces("application/json")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _service;
        private readonly ICreateEnderecoHandler _createHandler;
        private readonly IUpdateEnderecoHandler _updateHandler;
        private readonly IDeleteEnderecoHandler _deleteHandler;

        public EnderecoController(
            IEnderecoService service,
            ICreateEnderecoHandler createHandler,
            IUpdateEnderecoHandler updateHandler,
            IDeleteEnderecoHandler deleteHandler)
        {
            _service = service;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
        }

        [HttpGet]
        [EndpointSummary("Listar todos os endereços")]
        [EndpointDescription("Retorna a lista completa de endereços cadastrados no sistema.")]
        [ProducesResponseType(typeof(IEnumerable<Endereco>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var enderecos = await _service.ObterTodos();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        [EndpointSummary("Buscar endereço por ID")]
        [EndpointDescription("Retorna os dados de um endereço específico pelo seu identificador.")]
        [ProducesResponseType(typeof(Endereco), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var endereco = await _service.ObterPorId(id);
            return endereco is null ? NotFound() : Ok(endereco);
        }

        [HttpGet("cliente/{clienteId}")]
        [EndpointSummary("Buscar endereços por ClienteId")]
        [EndpointDescription("Retorna todos os endereços vinculados a um cliente específico.")]
        [ProducesResponseType(typeof(IEnumerable<Endereco>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByClienteId(int clienteId)
        {
            var enderecos = await _service.ObterPorClienteId(clienteId);
            return Ok(enderecos);
        }

        [HttpPost]
        [EndpointSummary("Cadastrar endereço")]
        [EndpointDescription("Cria um novo endereço vinculado a um cliente existente (IdCliente).")]
        [ProducesResponseType(typeof(Endereco), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateEnderecoCommand command)
        {
            var endereco = await _createHandler.Handle(command);
            return CreatedAtAction(nameof(GetById), new { id = endereco.Id }, endereco);
        }

        [HttpPatch]
        [EndpointSummary("Editar endereço")]
        [EndpointDescription("Atualiza os dados de um endereço existente.")]
        [ProducesResponseType(typeof(Endereco), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Patch([FromBody] UpdateEnderecoCommand command)
        {
            var endereco = await _updateHandler.Handle(command);
            return Ok(endereco);
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Inativar endereço")]
        [EndpointDescription("Realiza soft delete do endereço, alterando seu status para Inativo.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteHandler.Handle(new DeleteEnderecoCommand { Id = id });
            return NoContent();
        }
    }
}
