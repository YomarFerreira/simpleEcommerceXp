using System.Text.Json;
using Application.Commands.LogAlteracoes;
using Application.Commands.Produto;
using Application.Handlers.LogAlteracoes;
using Infrastructure.Repository.Interface;

namespace Application.Handlers.Produto
{
    public interface IAjustarEstoqueHandler
    {
        Task<Domain.Entities.Produto> Handle(AjustarEstoqueCommand command);
    }

    public class AjustarEstoqueHandler : IAjustarEstoqueHandler
    {
        private readonly IProdutoRepository _repository;
        private readonly ICreateLogAlteracoesHandler _logHandler;

        public AjustarEstoqueHandler(IProdutoRepository repository, ICreateLogAlteracoesHandler logHandler)
        {
            _repository = repository;
            _logHandler = logHandler;
        }

        public async Task<Domain.Entities.Produto> Handle(AjustarEstoqueCommand command)
        {
            var produto = await _repository.GetById(command.Id)
                ?? throw new KeyNotFoundException($"Produto {command.Id} não encontrado.");

            var valorAnterior = JsonSerializer.Serialize(produto);
            produto.AjustarEstoque(command.Operacao, command.Quantidade, command.NovoValor, command.CalcularMediaValor);
            await _repository.Update(produto);

            await _logHandler.Handle(new CreateLogAlteracoesCommand
            {
                Entidade = "Produto",
                ValorAnterior = valorAnterior,
                ValorPosterior = JsonSerializer.Serialize(produto),
                UsuarioCriacao = produto.UsuarioCriacao
            });

            return produto;
        }
    }
}
