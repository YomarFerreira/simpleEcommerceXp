using Domain.Entities;
using Domain.Properties;
using Infrastructure.Data;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Produto produto)
        {
            _context.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Produtos.FindAsync(id);
            if (entity is not null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Produto>> GetAll() =>
            await _context.Produtos.ToListAsync();

        public async Task<Produto?> GetById(int id) =>
            await _context.Produtos.FindAsync(id);

        public async Task<List<Produto>> GetByNome(string parteNome) =>
            await _context.Produtos
                .Where(p => p.Titulo.ToLower().Contains(parteNome.ToLower()))
                .ToListAsync();

        public async Task<List<Produto>> GetByPeriodo(DateTime dataInicial, DateTime dataFinal) =>
            await _context.Produtos
                .Where(p => p.DataCriacao >= dataInicial && p.DataCriacao <= dataFinal)
                .ToListAsync();

        public async Task<int> CountTotal(Status? status) =>
            await _context.Produtos
                .Where(p => status == null || p.Status == status)
                .CountAsync();
    }
}
