using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;

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

            var apiKey       = _configuration["SendGrid:ApiKey"]!;
            var remetente    = _configuration["Email:Remetente"]!;
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
                var client  = new SendGridClient(apiKey);
                var from    = new EmailAddress(remetente);
                var to      = new EmailAddress(destinatario);
                var message = MailHelper.CreateSingleEmail(from, to, assunto, corpo + rodape, null);
                message.SetClickTracking(false, false);

                var response = await client.SendEmailAsync(message);

                if (response.IsSuccessStatusCode)
                    _logger.LogInformation("[Email] Enviado: {Assunto} → {Destinatario}", assunto, destinatario);
                else
                {
                    var body = await response.Body.ReadAsStringAsync();
                    _logger.LogError("[Email] Falha ao enviar '{Assunto}'. Status: {Status} | {Body}",
                        assunto, response.StatusCode, body);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Email] Falha ao enviar '{Assunto}' para {Destinatario}.",
                    assunto, destinatario);
            }
        }
    }
}
