using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace Jobs.Services
{
    public interface IEmailService
    {
        Task EnviarAsync(string assunto, string corpo);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailHabilitadoService _habilitadoService;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, IEmailHabilitadoService habilitadoService, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _habilitadoService = habilitadoService;
            _logger = logger;
        }

        public async Task EnviarAsync(string assunto, string corpo)
        {
            if (!_habilitadoService.EstaHabilitado())
            {
                _logger.LogWarning("[Email] Envio desativado. '{Assunto}' não foi enviado.", assunto);
                return;
            }

            var smtp         = _configuration["Email:Smtp"]!;
            var porta        = int.Parse(_configuration["Email:Porta"]!);
            var remetente    = _configuration["Email:Remetente"]!;
            var senha        = _configuration["Email:Senha"]!;
            var destinatario = _configuration["Email:Destinatario"]!;
            var urlBase      = _configuration["Email:UrlBase"] ?? "http://localhost:5000";

            var rodape = $"""


------------------------------------------------------------
{urlBase}/email/desativar → Desativar envio de e-mails
{urlBase}/email/ativar    → Reativar envio de e-mails
------------------------------------------------------------
""";

            try
            {
                var mensagem = new MimeMessage();
                mensagem.From.Add(MailboxAddress.Parse(remetente));
                mensagem.To.Add(MailboxAddress.Parse(destinatario));
                mensagem.Subject = assunto;
                mensagem.Body = new TextPart("plain") { Text = corpo + rodape };

                using var client = new SmtpClient();
                await client.ConnectAsync(smtp, porta, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(remetente, senha);
                await client.SendAsync(mensagem);
                await client.DisconnectAsync(true);

                _logger.LogInformation("[Email] Enviado: {Assunto} → {Destinatario}", assunto, destinatario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Email] Falha ao enviar '{Assunto}' para {Destinatario}. Servidor: {Smtp}:{Porta}",
                    assunto, destinatario, smtp, porta);
            }
        }
    }
}
