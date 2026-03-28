using System.Text.Json;
using Application.Commands.Cliente;
using Application.Commands.LogAlteracoes;
using Application.Handlers.LogAlteracoes;
using Infrastructure.Repository.Interface;

namespace Application.Handlers.Cliente
{
    public interface IUpdateClienteHandler
    {
        Task<Domain.Entities.Cliente> Handle(UpdateClienteCommand command);
    }

    public class UpdateClienteHandler : IUpdateClienteHandler
    {
        private readonly IClienteRepository _repository;
        private readonly ICreateLogAlteracoesHandler _logHandler;

        public UpdateClienteHandler(IClienteRepository repository, ICreateLogAlteracoesHandler logHandler)
        {
            _repository = repository;
            _logHandler = logHandler;
        }

        public async Task<Domain.Entities.Cliente> Handle(UpdateClienteCommand command)
        {
            var cliente = await _repository.GetById(command.Id)
                ?? throw new KeyNotFoundException($"Cliente {command.Id} não encontrado.");

            var valorAnterior = JsonSerializer.Serialize(cliente);
            cliente.Update(command.Nome, command.Email, command.Telefone);
            await _repository.Update(cliente);

            await _logHandler.Handle(new CreateLogAlteracoesCommand
            {
                Entidade = "Cliente",
                ValorAnterior = valorAnterior,
                ValorPosterior = JsonSerializer.Serialize(cliente),
                UsuarioCriacao = cliente.UsuarioCriacao
            });

            return cliente;
        }
    }
}
