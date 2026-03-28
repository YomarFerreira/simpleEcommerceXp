using System.Security.Cryptography;
using System.Text;
using Application.Commands.Cliente;
using Domain.Entities;
using Infrastructure.Repository.Interface;

namespace Application.Handlers.Cliente
{
    public interface ICreateClienteHandler
    {
        Task<Domain.Entities.Cliente> Handle(CreateClienteCommand command);
    }

    public class CreateClienteHandler : ICreateClienteHandler
    {
        private readonly IClienteRepository _repository;

        public CreateClienteHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.Cliente> Handle(CreateClienteCommand command)
        {
            var senhaHash = HashSenha(command.Senha);

            var cliente = new Domain.Entities.Cliente(
                command.Nome, command.Email, command.Telefone,
                command.TipoDocumento, command.Documento,
                senhaHash, command.UsuarioCriacao);

            await _repository.Add(cliente);
            return cliente;
        }

        private static string HashSenha(string senha)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(senha));
            return Convert.ToBase64String(bytes);
        }
    }
}
