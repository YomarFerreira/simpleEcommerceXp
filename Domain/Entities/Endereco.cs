using Domain.Properties;

namespace Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public int IdCliente { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;

        public Endereco() { }

        public Endereco(int idCliente, string tipo, string logradouro, string numero,
            string complemento, string bairro, string cidade, string uf, string usuarioCriacao)
        {
            IdCliente = idCliente;
            Tipo = tipo;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Status = Status.Ativo;
            DataCriacao = DateTime.UtcNow;
            UsuarioCriacao = usuarioCriacao;
        }

        public void Update(string tipo, string logradouro, string numero,
            string complemento, string bairro, string cidade, string uf)
        {
            Tipo = tipo;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
        }

        public void Inativar() => Status = Status.Inativo;
    }
}
