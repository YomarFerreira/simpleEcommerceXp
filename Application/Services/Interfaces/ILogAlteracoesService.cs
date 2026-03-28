using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface ILogAlteracoesService
    {
        Task<List<LogAlteracoes>> ObterTodos();
    }
}
