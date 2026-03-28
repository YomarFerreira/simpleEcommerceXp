# ProjectEcommerce — Instruções para Claude

## Convenção de Comandos

O usuário pode invocar agentes com o padrão:

```
run <nome-do-agente> [--v]
```

Exemplos:
- `run seed.dados` — executa o agente de forma concisa
- `run seed.dados --v` — executa com modo verbose

## Regra obrigatória ao receber um comando `run`

1. **Sempre leia o arquivo `.claude/agents/<nome-do-agente>.md` antes de executar qualquer coisa.**
2. Siga o spec do arquivo à risca: quantidades, dados, ordem e regras definidas lá são obrigatórios.
3. Não improvise dados, quantidades ou ordem que não estejam no arquivo.
4. Se o agente chamar outros agentes (orquestrador), leia os arquivos de cada sub-agente também antes de executar.
5. Se o arquivo não existir, informe o usuário e não execute nada.

## Modo Verbose (`--v`)

Quando `--v` estiver presente, execute **sem usar o Agent tool** — faça tudo diretamente na conversa principal via Bash:

- Anuncie cada etapa antes de executá-la
- Exiba o payload completo de cada requisição HTTP
- Exiba a resposta completa (status + body) de cada chamada
- Pare e reporte imediatamente se qualquer chamada falhar

## Modo Silencioso (padrão, sem `--v`)

Execute via Agent tool de forma autônoma e retorne apenas o resumo final com os IDs criados e status de cada operação.
