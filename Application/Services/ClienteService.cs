using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Properties;
using Infrastructure.Repository.Interface;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cliente?> ObterPorId(int id) => await _repository.GetById(id);

        public async Task<List<Cliente>> ObterTodos() => await _repository.GetAll();

        public async Task<Cliente?> ObterPorDocumento(TipoDocumento tipoDocumento, string documento) =>
            await _repository.GetByDocumento(tipoDocumento, documento);

        public async Task<List<Cliente>> ObterPorNome(string parteNome) =>
            await _repository.GetByNome(parteNome);

        public async Task<Cliente?> ObterPorEmail(string email) =>
            await _repository.GetByEmail(email);

        public async Task<Cliente?> ObterPorTelefone(string telefone) =>
            await _repository.GetByTelefone(telefone);

        public async Task<int> ObterTotal(Status? status) =>
            await _repository.CountTotal(status);
    }
}
