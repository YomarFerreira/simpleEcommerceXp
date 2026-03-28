using Infrastructure.Data;
using Jobs.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Jobs.Jobs
{
    public class RelatorioLogsJob
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;
        private readonly ILogger<RelatorioLogsJob> _logger;

        public RelatorioLogsJob(AppDbContext context, IEmailService emailService, ILogger<RelatorioLogsJob> logger)
        {
            _context = context;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task Executar()
        {
            var hoje = DateTime.UtcNow.Date;
            var amanha = hoje.AddDays(1);

            var logs = await _context.Logs
                .Where(x => x.DataCriacao >= hoje && x.DataCriacao < amanha)
                .OrderBy(x => x.DataCriacao)
                .ToListAsync();

            if (logs.Count == 0)
            {
                _logger.LogInformation("[RelatorioLogs] {Data} | Nenhuma alteração no dia. E-mail não enviado.", hoje.ToString("dd/MM/yyyy"));
                return;
            }

            var porEntidade = logs.GroupBy(x => x.Entidade).OrderBy(g => g.Key);

            var linhas = new List<string>
            {
                "============================================================",
                $"  RELATÓRIO DE LOG DE ALTERAÇÕES — {hoje:dd/MM/yyyy}",
                "============================================================",
                $"  Gerado em    : {DateTime.UtcNow:dd/MM/yyyy HH:mm:ss} UTC",
                $"  Total        : {logs.Count} alteração(ões)",
                "------------------------------------------------------------",
                "",
                "  Por entidade:"
            };

            foreach (var grupo in porEntidade)
                linhas.Add($"    {grupo.Key,-20} {grupo.Count(),3} alteração(ões)");

            linhas.Add("");
            linhas.Add("------------------------------------------------------------");
            linhas.Add("  Detalhe das alterações:");
            linhas.Add("------------------------------------------------------------");

            foreach (var log in logs)
            {
                linhas.Add("");
                linhas.Add($"  [{log.DataCriacao:HH:mm:ss}] Entidade: {log.Entidade} | Usuário: {log.UsuarioCriacao}");
                linhas.Add($"  Antes  : {log.ValorAnterior}");
                linhas.Add($"  Depois : {log.ValorPosterior}");
            }

            linhas.Add("");
            linhas.Add("============================================================");

            var assunto = $"Relatório de Log de Alterações — {hoje:dd/MM/yyyy}";
            var corpo = string.Join(Environment.NewLine, linhas);

            await _emailService.EnviarAsync(assunto, corpo);

            _logger.LogInformation("[RelatorioLogs] {Data} | {Qtd} alteração(ões) | E-mail enviado.",
                hoje.ToString("dd/MM/yyyy"), logs.Count);
        }
    }
}
