using Domain.Entities;
using Domain.Properties;
using Infrastructure.Data;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Cliente cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Clientes.FindAsync(id);
            if (entity is not null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Cliente>> GetAll() =>
            await _context.Clientes.ToListAsync();

        public async Task<Cliente?> GetById(int id) =>
            await _context.Clientes.FindAsync(id);

        public async Task<Cliente?> GetByDocumento(TipoDocumento tipoDocumento, string documento) =>
            await _context.Clientes
                .FirstOrDefaultAsync(c => c.TipoDocumento == tipoDocumento && c.Documento == documento);

        public async Task<List<Cliente>> GetByNome(string parteNome) =>
            await _context.Clientes
                .Where(c => c.Nome.ToLower().Contains(parteNome.ToLower()))
                .ToListAsync();

        public async Task<Cliente?> GetByEmail(string email) =>
            await _context.Clientes
                .FirstOrDefaultAsync(c => c.Email.ToLower() == email.ToLower());

        public async Task<Cliente?> GetByTelefone(string telefone) =>
            await _context.Clientes
                .FirstOrDefaultAsync(c => c.Telefone == telefone);

        public async Task<int> CountTotal(Status? status) =>
            await _context.Clientes
                .Where(c => status == null || c.Status == status)
                .CountAsync();
    }
}
