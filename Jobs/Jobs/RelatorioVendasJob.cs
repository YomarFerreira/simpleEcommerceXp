using Domain.Properties;
using Infrastructure.Data;
using Jobs.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Jobs.Jobs
{
    public class RelatorioVendasJob
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;
        private readonly ILogger<RelatorioVendasJob> _logger;

        public RelatorioVendasJob(AppDbContext context, IEmailService emailService, ILogger<RelatorioVendasJob> logger)
        {
            _context = context;
            _emailService = emailService;
            _logger = logger;
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
                _logger.LogInformation("[RelatorioVendas] {Data} | Nenhuma venda no dia. E-mail não enviado.", hoje.ToString("dd/MM/yyyy"));
                return;
            }

            var totalVendas = pedidos.Sum(x => x.ValorFinal);
            var ticketMedio = totalVendas / pedidos.Count;

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
                "",
                "  Por tipo de pagamento:"
            };

            var porTipoPagamento = pedidos
                .GroupBy(x => x.TipoPagamento)
                .OrderByDescending(g => g.Count());

            foreach (var grupo in porTipoPagamento)
                linhas.Add($"    {grupo.Key,-20} {grupo.Count(),3} pedido(s)   R$ {grupo.Sum(x => x.ValorFinal):F2}");

            linhas.Add("");
            linhas.Add("------------------------------------------------------------");
            linhas.Add("  Detalhe dos pedidos:");
            linhas.Add("------------------------------------------------------------");

            foreach (var p in pedidos)
                linhas.Add($"  ID {p.Id,4} | Cliente {p.IdCliente,4} | Produto {p.IdProduto,4} | " +
                           $"R$ {p.ValorFinal:F2} | {p.TipoPagamento} | {p.NumeroParcelas}x | {p.DataCriacao:HH:mm:ss}");

            linhas.Add("");
            linhas.Add("============================================================");

            var assunto = $"Relatório de Vendas — {hoje:dd/MM/yyyy}";
            var corpo = string.Join(Environment.NewLine, linhas);

            await _emailService.EnviarAsync(assunto, corpo);

            _logger.LogInformation("[RelatorioVendas] {Data} | {Qtd} pedido(s) | R$ {Total:F2} | E-mail enviado.",
                hoje.ToString("dd/MM/yyyy"), pedidos.Count, totalVendas);
        }
    }
}
