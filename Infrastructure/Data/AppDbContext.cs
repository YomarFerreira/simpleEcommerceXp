using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<LogAlteracoes> Logs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(c => c.TipoDocumento)
                .HasConversion<string>();

            modelBuilder.Entity<Pedido>()
                .Property(p => p.TipoPagamento)
                .HasConversion<string>();

            modelBuilder.Entity<LogAlteracoes>()
                .Ignore(l => l.Status);
        }
    }
}
