using Application.Commands.Endereco;
using Infrastructure.Repository.Interface;

namespace Application.Handlers.Endereco
{
    public interface ICreateEnderecoHandler
    {
        Task<Domain.Entities.Endereco> Handle(CreateEnderecoCommand command);
    }

    public class CreateEnderecoHandler : ICreateEnderecoHandler
    {
        private readonly IEnderecoRepository _repository;

        public CreateEnderecoHandler(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.Endereco> Handle(CreateEnderecoCommand command)
        {
            var endereco = new Domain.Entities.Endereco(
                command.IdCliente, command.Tipo, command.Logradouro,
                command.Numero, command.Complemento, command.Bairro,
                command.Cidade, command.Uf, command.UsuarioCriacao);

            await _repository.Add(endereco);
            return endereco;
        }
    }
}
