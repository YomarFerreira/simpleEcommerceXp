using Domain.Entities;
using Domain.Properties;

namespace Application.Services.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente?> ObterPorId(int id);
        Task<List<Cliente>> ObterTodos();
        Task<Cliente?> ObterPorDocumento(TipoDocumento tipoDocumento, string documento);
        Task<List<Cliente>> ObterPorNome(string parteNome);
        Task<Cliente?> ObterPorEmail(string email);
        Task<Cliente?> ObterPorTelefone(string telefone);
        Task<int> ObterTotal(Status? status);
    }
}
