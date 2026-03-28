using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Repository.Interface;

namespace Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _repository;

        public EnderecoService(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Endereco?> ObterPorId(int id) => await _repository.GetById(id);

        public async Task<List<Endereco>> ObterTodos() => await _repository.GetAll();

        public async Task<List<Endereco>> ObterPorClienteId(int clienteId) =>
            await _repository.GetByClienteId(clienteId);
    }
}
