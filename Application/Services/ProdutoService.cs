using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Properties;
using Infrastructure.Repository.Interface;

namespace Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Produto?> ObterPorId(int id) => await _repository.GetById(id);

        public async Task<List<Produto>> ObterTodos() => await _repository.GetAll();

        public async Task<List<Produto>> ObterPorNome(string parteNome) =>
            await _repository.GetByNome(parteNome);

        public async Task<List<Produto>> ObterPorPeriodo(DateTime dataInicial, DateTime dataFinal) =>
            await _repository.GetByPeriodo(dataInicial.ToUniversalTime(), dataFinal.ToUniversalTime());

        public async Task<int> ObterTotal(Status? status) =>
            await _repository.CountTotal(status);
    }
}
