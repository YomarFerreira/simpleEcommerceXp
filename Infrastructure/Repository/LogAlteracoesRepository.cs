using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class LogAlteracoesRepository : ILogAlteracoesRepository
    {
        private readonly AppDbContext _context;

        public LogAlteracoesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(LogAlteracoes log)
        {
            _context.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LogAlteracoes>> GetAll() =>
            await _context.Logs.ToListAsync();

        public async Task<List<LogAlteracoes>> GetByDate(DateTime dataInicio, DateTime dataFim) =>
            await _context.Logs
                .Where(x => x.DataCriacao >= dataInicio && x.DataCriacao < dataFim)
                .ToListAsync();
    }
}
