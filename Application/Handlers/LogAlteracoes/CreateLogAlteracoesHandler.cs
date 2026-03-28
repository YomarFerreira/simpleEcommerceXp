using Application.Commands.LogAlteracoes;
using Infrastructure.Repository.Interface;

namespace Application.Handlers.LogAlteracoes
{
    public interface ICreateLogAlteracoesHandler
    {
        Task<Domain.Entities.LogAlteracoes> Handle(CreateLogAlteracoesCommand command);
    }

    public class CreateLogAlteracoesHandler : ICreateLogAlteracoesHandler
    {
        private readonly ILogAlteracoesRepository _repository;

        public CreateLogAlteracoesHandler(ILogAlteracoesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.LogAlteracoes> Handle(CreateLogAlteracoesCommand command)
        {
            var log = new Domain.Entities.LogAlteracoes(
                command.Entidade, command.ValorAnterior,
                command.ValorPosterior, command.UsuarioCriacao);

            await _repository.Add(log);
            return log;
        }
    }
}
