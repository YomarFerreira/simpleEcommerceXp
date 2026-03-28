using Domain.Entities;

namespace Infrastructure.Repository.Interface
{
    public interface IEnderecoRepository
    {
        Task Add(Endereco endereco);
        Task Update(Endereco endereco);
        Task Delete(int id);
        Task<Endereco?> GetById(int id);
        Task<List<Endereco>> GetAll();
        Task<List<Endereco>> GetByClienteId(int clienteId);
    }
}
