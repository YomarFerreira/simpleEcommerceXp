namespace Domain.Properties
{
    public static class TipoPagamentoRegras
    {
        private static readonly Dictionary<TipoPagamento, (bool Parcelavel, int MaxParcelas)> _regras = new()
        {
            { TipoPagamento.CreditoUmaVez,    (false, 1)  },
            { TipoPagamento.CreditoParcelado, (true,  10) },
            { TipoPagamento.DebitoUmaVez,     (false, 1)  },
            { TipoPagamento.PixUmaVez,        (false, 1)  },
            { TipoPagamento.PixParcelado,     (true,  6)  },
            { TipoPagamento.BoletoUmaVez,     (false, 1)  },
            { TipoPagamento.BoletoParcelado,  (true,  12) },
        };

        public static bool EhParcelavel(TipoPagamento tipo) => _regras[tipo].Parcelavel;
        public static int MaxParcelas(TipoPagamento tipo)   => _regras[tipo].MaxParcelas;
    }
}
