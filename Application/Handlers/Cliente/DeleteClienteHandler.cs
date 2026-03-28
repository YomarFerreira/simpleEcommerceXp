using Application.Commands.Cliente;
using Infrastructure.Repository.Interface;

namespace Application.Handlers.Cliente
{
    public interface IDeleteClienteHandler
    {
        Task Handle(DeleteClienteCommand command);
    }

    public class DeleteClienteHandler : IDeleteClienteHandler
    {
        private readonly IClienteRepository _repository;

        public DeleteClienteHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteClienteCommand command)
        {
            var cliente = await _repository.GetById(command.Id)
                ?? throw new KeyNotFoundException($"Cliente {command.Id} não encontrado.");

            cliente.Inativar();
            await _repository.Update(cliente);
        }
    }
}
