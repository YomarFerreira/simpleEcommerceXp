using Application.Commands.Cliente;
using Application.Handlers.Cliente;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Properties;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    [Tags("Clientes")]
    [Produces("application/json")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        private readonly ICreateClienteHandler _createHandler;
        private readonly IUpdateClienteHandler _updateHandler;
        private readonly IDeleteClienteHandler _deleteHandler;
        private readonly IAlterarSenhaHandler _alterarSenhaHandler;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(
            IClienteService service,
            ICreateClienteHandler createHandler,
            IUpdateClienteHandler updateHandler,
            IDeleteClienteHandler deleteHandler,
            IAlterarSenhaHandler alterarSenhaHandler,
            ILogger<ClienteController> logger)
        {
            _service = service;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
            _alterarSenhaHandler = alterarSenhaHandler;
            _logger = logger;
        }

        [HttpGet]
        [EndpointSummary("Listar todos os clientes")]
        [EndpointDescription("Retorna a lista completa de clientes cadastrados no sistema.")]
        [ProducesResponseType(typeof(IEnumerable<Cliente>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("[ClienteController] GetAll iniciado");
            try
            {
                var clientes = await _service.ObterTodos();
                _logger.LogInformation("[ClienteController] GetAll concluído - {Count} clientes", clientes.Count());
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[ClienteController] GetAll falhou");
                throw;
            }
        }

        [HttpGet("{id}")]
        [EndpointSummary("Buscar cliente por ID")]
        [EndpointDescription("Retorna os dados de um cliente específico pelo seu identificador.")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _service.ObterPorId(id);
            return cliente is null ? NotFound() : Ok(cliente);
        }

        [HttpGet("documento")]
        [EndpointSummary("Buscar cliente por documento")]
        [EndpointDescription("Retorna o cliente que possui o documento informado. O tipo de documento deve ser: CPF=1, CNPJ=2, RG=3, Passaporte=4.")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByDocumento([FromQuery] TipoDocumento tipoDocumento, [FromQuery] string documento)
        {
            var cliente = await _service.ObterPorDocumento(tipoDocumento, documento);
            return cliente is null ? NotFound() : Ok(cliente);
        }

        [HttpGet("nome")]
        [EndpointSummary("Buscar clientes por parte do nome")]
        [EndpointDescription("Retorna todos os clientes cujo nome contenha o trecho informado. A busca é case-insensitive.")]
        [ProducesResponseType(typeof(IEnumerable<Cliente>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByNome([FromQuery] string nome)
        {
            var clientes = await _service.ObterPorNome(nome);
            return Ok(clientes);
        }

        [HttpGet("email")]
        [EndpointSummary("Buscar cliente por e-mail")]
        [EndpointDescription("Retorna o cliente que possui o e-mail informado. A busca é case-insensitive.")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            var cliente = await _service.ObterPorEmail(email);
            return cliente is null ? NotFound() : Ok(cliente);
        }

        [HttpGet("telefone")]
        [EndpointSummary("Buscar cliente por telefone")]
        [EndpointDescription("Retorna o cliente que possui o telefone informado.")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTelefone([FromQuery] string telefone)
        {
            var cliente = await _service.ObterPorTelefone(telefone);
            return cliente is null ? NotFound() : Ok(cliente);
        }

        [HttpPost]
        [EndpointSummary("Cadastrar cliente")]
        [EndpointDescription("Cria um novo cliente. A senha é armazenada com hash SHA-256.")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateClienteCommand command)
        {
            var cliente = await _createHandler.Handle(command);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPatch]
        [EndpointSummary("Editar cliente")]
        [EndpointDescription("Atualiza nome, email e telefone de um cliente existente.")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Patch([FromBody] UpdateClienteCommand command)
        {
            var cliente = await _updateHandler.Handle(command);
            return Ok(cliente);
        }

        [HttpPatch("{id}/senha")]
        [EndpointSummary("Alterar senha")]
        [EndpointDescription("Altera a senha do cliente. Requer a senha atual para confirmação.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AlterarSenha(int id, [FromBody] AlterarSenhaCommand command)
        {
            command.Id = id;
            try
            {
                await _alterarSenhaHandler.Handle(command);
                return NoContent();
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
        [EndpointSummary("Inativar cliente")]
        [EndpointDescription("Realiza soft delete do cliente, alterando seu status para Inativo.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteHandler.Handle(new DeleteClienteCommand { Id = id });
            return NoContent();
        }
    }
}
