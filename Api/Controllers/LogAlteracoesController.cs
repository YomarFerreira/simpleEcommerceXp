using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/logs")]
    [Tags("Logs de Alterações")]
    [Produces("application/json")]
    public class LogAlteracoesController : ControllerBase
    {
        private readonly ILogAlteracoesService _service;

        public LogAlteracoesController(ILogAlteracoesService service)
        {
            _service = service;
        }

        [HttpGet]
        [EndpointSummary("Listar todos os logs de alterações")]
        [EndpointDescription("Retorna o histórico completo de alterações registradas no sistema. Os logs são gerados automaticamente a cada edição de registro.")]
        [ProducesResponseType(typeof(IEnumerable<LogAlteracoes>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var logs = await _service.ObterTodos();
            return Ok(logs);
        }
    }
}
