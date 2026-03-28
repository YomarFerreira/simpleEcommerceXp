using System.Text.Json.Serialization;
using Domain.Properties;

namespace Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Telefone { get; private set; } = string.Empty;
        public TipoDocumento TipoDocumento { get; private set; }
        public string Documento { get; private set; } = string.Empty;
        [JsonIgnore]
        public string Senha { get; private set; } = string.Empty;

        public Cliente() { }

        public Cliente(string nome, string email, string telefone, TipoDocumento tipoDocumento,
            string documento, string senhaHash, string usuarioCriacao)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            TipoDocumento = tipoDocumento;
            Documento = documento;
            Senha = senhaHash;
            Status = Status.Ativo;
            DataCriacao = DateTime.UtcNow;
            UsuarioCriacao = usuarioCriacao;
        }

        public void Update(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public void AlterarSenha(string senhaHash)
        {
            Senha = senhaHash;
        }

        public void Inativar() => Status = Status.Inativo;
    }
}
