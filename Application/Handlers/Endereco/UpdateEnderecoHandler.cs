using System.Text.Json;
using Application.Commands.Endereco;
using Application.Commands.LogAlteracoes;
using Application.Handlers.LogAlteracoes;
using Infrastructure.Repository.Interface;

namespace Application.Handlers.Endereco
{
    public interface IUpdateEnderecoHandler
    {
        Task<Domain.Entities.Endereco> Handle(UpdateEnderecoCommand command);
    }

    public class UpdateEnderecoHandler : IUpdateEnderecoHandler
    {
        private readonly IEnderecoRepository _repository;
        private readonly ICreateLogAlteracoesHandler _logHandler;

        public UpdateEnderecoHandler(IEnderecoRepository repository, ICreateLogAlteracoesHandler logHandler)
        {
            _repository = repository;
            _logHandler = logHandler;
        }

        public async Task<Domain.Entities.Endereco> Handle(UpdateEnderecoCommand command)
        {
            var endereco = await _repository.GetById(command.Id)
                ?? throw new KeyNotFoundException($"Endereço {command.Id} não encontrado.");

            var valorAnterior = JsonSerializer.Serialize(endereco);
            endereco.Update(command.Tipo, command.Logradouro, command.Numero,
                command.Complemento, command.Bairro, command.Cidade, command.Uf);
            await _repository.Update(endereco);

            await _logHandler.Handle(new CreateLogAlteracoesCommand
            {
                Entidade = "Endereco",
                ValorAnterior = valorAnterior,
                ValorPosterior = JsonSerializer.Serialize(endereco),
                UsuarioCriacao = endereco.UsuarioCriacao
            });

            return endereco;
        }
    }
}
