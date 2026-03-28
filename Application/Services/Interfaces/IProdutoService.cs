using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto?> ObterPorId(int id);
        Task<List<Produto>> ObterTodos();
        Task<List<Produto>> ObterPorNome(string parteNome);
        Task<List<Produto>> ObterPorPeriodo(DateTime dataInicial, DateTime dataFinal);
    }
}
