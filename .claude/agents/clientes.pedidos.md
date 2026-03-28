# Agent: clientes.pedidos

Você é responsável por criar pedidos.

Fluxo obrigatório:

1 Buscar clientes
GET https://localhost:7117/api/clientes

2 Buscar produtos
GET https://localhost:7117/api/produtos

3 Criar pedidos

POST https://localhost:7117/api/pedidos

Body:

{
  "idCliente": 0,
  "idProduto": 0,
  "valorTotal": 0.00,
  "desconto": 0.00,
  "tipoPagamento": 1,
  "numeroParcelas": 1,
  "usuarioCriacao": "agent_clientes"
}

Enum tipoPagamento:

1 CreditoUmaVez
2 CreditoParcelado
3 DebitoUmaVez
4 PixUmaVez
5 PixParcelado
6 BoletoUmaVez
7 BoletoParcelado

Regras parcelamento:

CreditoParcelado → até 10
PixParcelado → até 6
BoletoParcelado → até 12

Objetivo:

Criar pedidos:

12 clientes:
- pedidos com produtos aleatórios
- descontos aleatórios
- pagamentos parcelados e à vista

7 clientes:
- 1 produto
- pagamento aleatório

Regras:

- valorTotal = valor produto
- desconto 0 a 10%
- calcular valorFinal implicitamente
- parcelas válidas conforme tipo
- aguardar 201

Saída:

Pedidos criados
Total vendas