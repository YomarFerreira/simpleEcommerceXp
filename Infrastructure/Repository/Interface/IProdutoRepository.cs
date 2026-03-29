using Domain.Entities;
using Domain.Properties;

namespace Infrastructure.Repository.Interface
{
    public interface IProdutoRepository
    {
        Task Add(Produto produto);
        Task Update(Produto produto);
        Task Delete(int id);
        Task<Produto?> GetById(int id);
        Task<List<Produto>> GetAll();
        Task<List<Produto>> GetByNome(string parteNome);
        Task<List<Produto>> GetByPeriodo(DateTime dataInicial, DateTime dataFinal);
        Task<int> CountTotal(Status? status);
    }
}
