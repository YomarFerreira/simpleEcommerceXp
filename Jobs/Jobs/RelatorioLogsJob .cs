using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Jobs.Jobs
{
    public class RelatorioLogsJob
    {
        private readonly AppDbContext _context;
        private readonly ILogger<RelatorioLogsJob> _logger;
        private readonly string _pastaRelatorios;

        public RelatorioLogsJob(AppDbContext context, ILogger<RelatorioLogsJob> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _pastaRelatorios = Path.GetFullPath(configuration["RelatoriosPath"] ?? "Relatorios");
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
                _logger.LogInformation("[RelatorioLogs] {Data} | Nenhuma alteração no dia. Relatório não gerado.", hoje.ToString("dd/MM/yyyy"));
                return;
            }

            Directory.CreateDirectory(_pastaRelatorios);

            var nomeArquivo = $"relatorio_log_alteracoes_{hoje:yyyy-MM-dd}.txt";
            var caminhoArquivo = Path.Combine(_pastaRelatorios, nomeArquivo);

            var porEntidade = logs.GroupBy(x => x.Entidade).OrderBy(g => g.Key);

            var linhas = new List<string>
            {
                "============================================================",
                $"  RELATÓRIO DE LOG DE ALTERAÇÕES — {hoje:dd/MM/yyyy}",
                "============================================================",
                $"  Gerado em    : {DateTime.UtcNow:dd/MM/yyyy HH:mm:ss} UTC",
                $"  Total        : {logs.Count} alteração(ões)",
                "------------------------------------------------------------",
                ""
            };

            linhas.Add("  Por entidade:");
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

            await File.WriteAllLinesAsync(caminhoArquivo, linhas);

            _logger.LogInformation("[RelatorioLogs] {Data} | {Qtd} alteração(ões) | Arquivo: {Arquivo}",
                hoje.ToString("dd/MM/yyyy"), logs.Count, nomeArquivo);
        }
    }
}
