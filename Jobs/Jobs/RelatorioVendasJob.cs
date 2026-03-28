using Domain.Properties;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Jobs.Jobs
{
    public class RelatorioVendasJob
    {
        private readonly AppDbContext _context;
        private readonly ILogger<RelatorioVendasJob> _logger;
        private readonly string _pastaRelatorios;

        public RelatorioVendasJob(AppDbContext context, ILogger<RelatorioVendasJob> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _pastaRelatorios = Path.GetFullPath(configuration["RelatoriosPath"] ?? "Relatorios");
        }

        public async Task Executar()
        {
            var hoje = DateTime.UtcNow.Date;
            var amanha = hoje.AddDays(1);

            var pedidos = await _context.Pedidos
                .Where(x => x.Status == Status.Ativo
                         && x.DataCriacao >= hoje
                         && x.DataCriacao < amanha)
                .OrderBy(x => x.DataCriacao)
                .ToListAsync();

            if (pedidos.Count == 0)
            {
                _logger.LogInformation("[RelatorioVendas] {Data} | Nenhuma venda no dia. Relatório não gerado.", hoje.ToString("dd/MM/yyyy"));
                return;
            }

            var totalVendas = pedidos.Sum(x => x.ValorFinal);
            var ticketMedio = totalVendas / pedidos.Count;

            Directory.CreateDirectory(_pastaRelatorios);

            var nomeArquivo = $"relatorio_vendas_{hoje:yyyy-MM-dd}.txt";
            var caminhoArquivo = Path.Combine(_pastaRelatorios, nomeArquivo);

            var linhas = new List<string>
            {
                "============================================================",
                $"  RELATÓRIO DE VENDAS — {hoje:dd/MM/yyyy}",
                "============================================================",
                $"  Gerado em : {DateTime.UtcNow:dd/MM/yyyy HH:mm:ss} UTC",
                $"  Pedidos   : {pedidos.Count}",
                $"  Total     : R$ {totalVendas:F2}",
                $"  Ticket    : R$ {ticketMedio:F2}",
                "------------------------------------------------------------",
                ""
            };

            var porTipoPagamento = pedidos
                .GroupBy(x => x.TipoPagamento)
                .OrderByDescending(g => g.Count());

            linhas.Add("  Por tipo de pagamento:");
            foreach (var grupo in porTipoPagamento)
                linhas.Add($"    {grupo.Key,-20} {grupo.Count(),3} pedido(s)   R$ {grupo.Sum(x => x.ValorFinal):F2}");

            linhas.Add("");
            linhas.Add("------------------------------------------------------------");
            linhas.Add("  Detalhe dos pedidos:");
            linhas.Add("------------------------------------------------------------");

            foreach (var p in pedidos)
            {
                linhas.Add($"  ID {p.Id,4} | Cliente {p.IdCliente,4} | Produto {p.IdProduto,4} | " +
                           $"R$ {p.ValorFinal:F2} | {p.TipoPagamento} | {p.NumeroParcelas}x | " +
                           $"{p.DataCriacao:HH:mm:ss}");
            }

            linhas.Add("");
            linhas.Add("============================================================");

            await File.WriteAllLinesAsync(caminhoArquivo, linhas);

            _logger.LogInformation("[RelatorioVendas] {Data} | {Qtd} pedido(s) | R$ {Total:F2} | Arquivo: {Arquivo}",
                hoje.ToString("dd/MM/yyyy"), pedidos.Count, totalVendas, nomeArquivo);
        }
    }
}
