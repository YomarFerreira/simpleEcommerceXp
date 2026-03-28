using Application.Commands.Produto;
using Infrastructure.Repository.Interface;

namespace Application.Handlers.Produto
{
    public interface ICreateProdutoHandler
    {
        Task<Domain.Entities.Produto> Handle(CreateProdutoCommand command);
    }

    public class CreateProdutoHandler : ICreateProdutoHandler
    {
        private readonly IProdutoRepository _repository;

        public CreateProdutoHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.Produto> Handle(CreateProdutoCommand command)
        {
            var produto = new Domain.Entities.Produto(
                command.Titulo, command.Descricao, command.Valor, command.Estoque, command.UsuarioCriacao);

            await _repository.Add(produto);
            return produto;
        }
    }
}
