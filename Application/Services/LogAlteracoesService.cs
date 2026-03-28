using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Repository.Interface;

namespace Application.Services
{
    public class LogAlteracoesService : ILogAlteracoesService
    {
        private readonly ILogAlteracoesRepository _repository;

        public LogAlteracoesService(ILogAlteracoesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LogAlteracoes>> ObterTodos() => await _repository.GetAll();
    }
}
