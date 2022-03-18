# Desafio ASP.NET Core

## Sobre

O objetivo deste projeto foi desenvolver um app web com ASP.NET Core que tinham como requisitos principais:

- Visualizar os caminhões cadastrados;
    - As propriedades mínimas do caminhão deverão ser:
        - Modelo (Poderá aceitar apenas FH e FM)
        - Ano de Fabricação (Ano deverá ser o atual)
        - Ano Modelo (Poderá ser o atual ou o ano subsequente)
- Atualizar as informações de um caminhão;
- Excluir um caminhão;
- Inserir um novo caminhão.

Requisitos secundários:

- Poderão existir vários modelos de caminhões.
    - Os modelos permitidos serão somente (FH e FM)

- Utilizar ASP.NET Core;
- Utilizar base de dados local;
- Utilizar ORM para mapear as tabelas de base de dados
  - Utilizar “Migrations” para criação da base de dados;
  - A criação da base de dados deverá ser automática (sem a necessidade de utilizar algum comando adicional).
- Criar testes unitários (Cobrir ao menos 80% dos fluxos)

## Execução

Todo o projeto está baseado no .NET 6.0.

## Principais ferramentas e tecnologias

- .NET 6.0
- Entity Framework
- SQLite
- Moq
- XUnit
- NuGet
- Coverlet

## Boas práticas e observações

- Versionar apenas os arquivos necessários (.gitignore)
- Assinatura de commits com GPG
- Commit Semântico