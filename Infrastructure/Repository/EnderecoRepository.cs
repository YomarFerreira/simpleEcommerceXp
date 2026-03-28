using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AppDbContext _context;

        public EnderecoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Endereco endereco)
        {
            _context.Add(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Endereco endereco)
        {
            _context.Update(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Enderecos.FindAsync(id);
            if (entity is not null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Endereco>> GetAll() =>
            await _context.Enderecos.ToListAsync();

        public async Task<Endereco?> GetById(int id) =>
            await _context.Enderecos.FindAsync(id);

        public async Task<List<Endereco>> GetByClienteId(int clienteId) =>
            await _context.Enderecos
                .Where(e => e.IdCliente == clienteId)
                .ToListAsync();
    }
}
