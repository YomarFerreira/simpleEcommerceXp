using Application.Commands.Produto;
using Infrastructure.Repository.Interface;

namespace Application.Handlers.Produto
{
    public interface IDeleteProdutoHandler
    {
        Task Handle(DeleteProdutoCommand command);
    }

    public class DeleteProdutoHandler : IDeleteProdutoHandler
    {
        private readonly IProdutoRepository _repository;

        public DeleteProdutoHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteProdutoCommand command)
        {
            var produto = await _repository.GetById(command.Id)
                ?? throw new KeyNotFoundException($"Produto {command.Id} não encontrado.");

            produto.Inativar();
            await _repository.Update(produto);
        }
    }
}
