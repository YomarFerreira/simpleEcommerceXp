using System.Security.Cryptography;
using System.Text;
using Application.Commands.Cliente;
using Application.Commands.LogAlteracoes;
using Application.Handlers.LogAlteracoes;
using Infrastructure.Repository.Interface;

namespace Application.Handlers.Cliente
{
    public interface IAlterarSenhaHandler
    {
        Task Handle(AlterarSenhaCommand command);
    }

    public class AlterarSenhaHandler : IAlterarSenhaHandler
    {
        private readonly IClienteRepository _repository;
        private readonly ICreateLogAlteracoesHandler _logHandler;

        public AlterarSenhaHandler(IClienteRepository repository, ICreateLogAlteracoesHandler logHandler)
        {
            _repository = repository;
            _logHandler = logHandler;
        }

        public async Task Handle(AlterarSenhaCommand command)
        {
            var cliente = await _repository.GetById(command.Id)
                ?? throw new KeyNotFoundException($"Cliente {command.Id} não encontrado.");

            var senhaAtualHash = HashSenha(command.SenhaAtual);
            if (cliente.Senha != senhaAtualHash)
                throw new InvalidOperationException("Senha atual incorreta.");

            cliente.AlterarSenha(HashSenha(command.NovaSenha));
            await _repository.Update(cliente);

            await _logHandler.Handle(new CreateLogAlteracoesCommand
            {
                Entidade = "Cliente",
                ValorAnterior = $"{{\"id\":{cliente.Id},\"campo\":\"Senha\",\"valor\":\"***\"}}",
                ValorPosterior = $"{{\"id\":{cliente.Id},\"campo\":\"Senha\",\"valor\":\"***\"}}",
                UsuarioCriacao = cliente.UsuarioCriacao
            });
        }

        private static string HashSenha(string senha)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(senha));
            return Convert.ToBase64String(bytes);
        }
    }
}
