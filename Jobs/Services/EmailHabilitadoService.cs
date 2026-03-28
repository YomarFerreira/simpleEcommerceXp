namespace Jobs.Services
{
    public interface IEmailHabilitadoService
    {
        bool EstaHabilitado();
        void Desativar();
        void Ativar();
    }

    public class EmailHabilitadoService : IEmailHabilitadoService
    {
        private static readonly string _arquivoFlag =
            Path.Combine(AppContext.BaseDirectory, "email_desativado.flag");

        public bool EstaHabilitado() => !File.Exists(_arquivoFlag);

        public void Desativar() =>
            File.WriteAllText(_arquivoFlag, DateTime.UtcNow.ToString("o"));

        public void Ativar()
        {
            if (File.Exists(_arquivoFlag))
                File.Delete(_arquivoFlag);
        }
    }
}
