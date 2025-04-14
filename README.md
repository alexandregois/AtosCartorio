# Atos Cartorio
Menu Ferramentas / Recriar Banco de Dados
- Recria o banco limpando os dados.

# AtosCartorio - Testes

Este diretório contém os testes unitários para o sistema de cartório, organizados por tipo de registro:

- **Obito**: Testes para os formulários de registro e listagem de óbitos
- **Nascimento**: Testes para os formulários de registro e listagem de nascimentos
- **Casamento**: Testes para os formulários de registro e listagem de casamentos

## Requisitos

Para executar os testes, você precisa ter instalado:

1. Visual Studio 2022
2. MSTest
3. Moq (para mocking)

## Como executar os testes

Você pode executar os testes de diversas formas:

### No Visual Studio:
1. Abra o Test Explorer (Menu: Test > Test Explorer)
2. Clique em "Run All Tests" para executar todos os testes

### Via console:
```
dotnet test
```

## Estrutura de testes

Cada classe de teste segue um padrão:

1. **Testes de validação**: Verificam se os campos dos formulários estão sendo validados corretamente
2. **Testes de carregamento**: Verificam se os dados são carregados corretamente nos formulários
3. **Testes de persistência**: Verificam se os dados são salvos corretamente
4. **Testes de UI**: Verificam comportamentos específicos da interface

## Adicionando novos testes

Ao adicionar novos recursos ao sistema, considere adicionar testes correspondentes seguindo a estrutura existente.

