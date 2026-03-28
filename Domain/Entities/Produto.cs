using Domain.Properties;

namespace Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string Titulo { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public decimal Valor { get; private set; }
        public int Estoque { get; private set; }

        public Produto() { }

        public Produto(string titulo, string descricao, decimal valor, int estoque, string usuarioCriacao)
        {
            Titulo = titulo;
            Descricao = descricao;
            Valor = valor;
            Estoque = estoque;
            Status = Status.Ativo;
            DataCriacao = DateTime.UtcNow;
            UsuarioCriacao = usuarioCriacao;
        }

        public void Update(string titulo, string descricao, decimal valor)
        {
            Titulo = titulo;
            Descricao = descricao;
            Valor = valor;
        }

        public void AjustarEstoque(TipoAjusteEstoque tipo, int quantidade, decimal? novoValor, bool calcularMediaValor)
        {
            if (tipo == TipoAjusteEstoque.Debito)
            {
                if (quantidade > Estoque)
                    throw new InvalidOperationException(
                        $"Estoque insuficiente. Estoque atual: {Estoque}, débito solicitado: {quantidade}.");

                if (novoValor.HasValue)
                {
                    var estoqueResultante = Estoque - quantidade;
                    Valor = calcularMediaValor && estoqueResultante > 0
                        ? (Estoque * Valor + quantidade * novoValor.Value) / estoqueResultante
                        : novoValor.Value;
                }

                Estoque -= quantidade;
            }
            else
            {
                if (novoValor.HasValue)
                {
                    Valor = calcularMediaValor && Estoque > 0
                        ? (Estoque * Valor + quantidade * novoValor.Value) / (Estoque + quantidade)
                        : novoValor.Value;
                }

                Estoque += quantidade;
            }
        }

        public void Inativar() => Status = Status.Inativo;
    }
}
