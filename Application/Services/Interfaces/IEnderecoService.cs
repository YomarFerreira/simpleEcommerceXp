using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco?> ObterPorId(int id);
        Task<List<Endereco>> ObterTodos();
        Task<List<Endereco>> ObterPorClienteId(int clienteId);
    }
}
