using Domain.Entities;
using Domain.Properties;

namespace Infrastructure.Repository.Interface
{
    public interface IClienteRepository
    {
        Task Add(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(int id);
        Task<Cliente?> GetById(int id);
        Task<List<Cliente>> GetAll();
        Task<Cliente?> GetByDocumento(TipoDocumento tipoDocumento, string documento);
        Task<List<Cliente>> GetByNome(string parteNome);
        Task<Cliente?> GetByEmail(string email);
        Task<Cliente?> GetByTelefone(string telefone);
        Task<int> CountTotal(Status? status);
    }
}
