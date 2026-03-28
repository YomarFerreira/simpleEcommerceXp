using Domain.Entities;
using Domain.Properties;
using Infrastructure.Data;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Pedido pedido)
        {
            _context.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Pedido pedido)
        {
            _context.Update(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Pedidos.FindAsync(id);
            if (entity is not null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Pedido>> GetAll() =>
            await _context.Pedidos.ToListAsync();

        public async Task<Pedido?> GetById(int id) =>
            await _context.Pedidos.FindAsync(id);

        public async Task<List<Pedido>> GetByPeriodo(DateTime dataInicial, DateTime dataFinal) =>
            await _context.Pedidos
                .Where(p => p.DataCriacao >= dataInicial && p.DataCriacao <= dataFinal)
                .ToListAsync();

        public async Task<List<Pedido>> GetByClienteId(int clienteId) =>
            await _context.Pedidos
                .Where(p => p.IdCliente == clienteId)
                .ToListAsync();

        public async Task<List<Pedido>> GetByProdutoId(int produtoId) =>
            await _context.Pedidos
                .Where(p => p.IdProduto == produtoId)
                .ToListAsync();

        public async Task<List<Pedido>> GetByStatusEntrega(StatusEntrega statusEntrega) =>
            await _context.Pedidos
                .Where(p => p.StatusEntrega == statusEntrega)
                .ToListAsync();
    }
}
