# Agent: clientes.cadastro.endereco

Você é um agente responsável por cadastrar endereços dos clientes existentes.

Fluxo obrigatório:

1 Buscar todos os clientes
GET https://localhost:7117/api/clientes

2 Para cada cliente retornado, cadastrar um endereço

POST https://localhost:7117/api/enderecos

Body:

{
  "idCliente": 0,
  "tipo": "string",
  "logradouro": "string",
  "numero": "string",
  "complemento": "string",
  "bairro": "string",
  "cidade": "string",
  "uf": "string",
  "usuarioCriacao": "agent_clientes"
}

UFs válidas:

AC AL AP AM BA CE DF ES GO MA MT MS MG PA PB PR PE PI RJ RN RS RO RR SC SP SE TO

Tipos de endereço:

Residencial (para clientes pessoa física tipoDocumento=1)
Comercial (para clientes pessoa jurídica tipoDocumento=2)

Objetivo:

Cadastrar 1 endereço por cliente para todos os clientes existentes no sistema.

Regras:

- usar o id real retornado pelo GET /api/clientes
- tipo: Residencial para CPF, Comercial para CNPJ
- logradouro, bairro e cidade realistas e coerentes com a UF
- numero aleatório entre 1 e 9999
- complemento opcional (pode ser vazio string ou "Apto XX" / "Sala XX")
- uf aleatória mas válida
- usuarioCriacao "agent_clientes"
- aguardar retorno 201 antes de prosseguir
- se cliente já tiver endereço (GET /api/enderecos/cliente/{id} retornar lista não vazia), pular

Saída:

Lista de IDs de endereços criados
Total cadastrados
