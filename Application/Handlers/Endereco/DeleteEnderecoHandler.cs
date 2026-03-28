using Application.Commands.Endereco;
using Infrastructure.Repository.Interface;

namespace Application.Handlers.Endereco
{
    public interface IDeleteEnderecoHandler
    {
        Task Handle(DeleteEnderecoCommand command);
    }

    public class DeleteEnderecoHandler : IDeleteEnderecoHandler
    {
        private readonly IEnderecoRepository _repository;

        public DeleteEnderecoHandler(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteEnderecoCommand command)
        {
            var endereco = await _repository.GetById(command.Id)
                ?? throw new KeyNotFoundException($"Endereço {command.Id} não encontrado.");

            endereco.Inativar();
            await _repository.Update(endereco);
        }
    }
}
