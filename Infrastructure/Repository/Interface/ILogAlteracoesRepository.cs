using Domain.Entities;

namespace Infrastructure.Repository.Interface
{
    public interface ILogAlteracoesRepository
    {
        Task Add(LogAlteracoes log);
        Task<List<LogAlteracoes>> GetAll();
        Task<List<LogAlteracoes>> GetByDate(DateTime dataInicio, DateTime dataFim);
    }
}
