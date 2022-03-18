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

Todo o projeto está baseado no [.NET 6.0](https://docs.microsoft.com/pt-br/dotnet/core/install). Também é necessário o
terminal [Git](https://docs.github.com/pt/authentication/connecting-to-github-with-ssh/generating-a-new-ssh-key-and-adding-it-to-the-ssh-agent)
com SSH configurado para fazer o clone do projeto.

```
git clone git@github.com:lripardo/DesafioAspNetCore1.git
```

```
cd DesafioAspNetCore1
```

Para executar a aplicação:

```
dotnet run --project DesafioAspNetCore1
```

O servidor irá abrir por padrão em <http://localhost:5213> ou no link em que o console indicar.

Após abrir o link, esta será a página inicial:

![alt home](Images/home.png)

No menu do topo, clique em [Criar](http://localhost:5213/Trucks/Create) para adicionar um caminhão no banco de dados.

![alt create](Images/create.png)

As validações estão aplicadas de acordo com os requisitos então preencha todos os campos corretamente e clique no
botão "Criar". Após o processo você será redirecionado para a lista de caminhões onde poderá ver o seu recém cadastrado
veículo.

![alt create_and_list](Images/saved_and_list.png)

Os processos de exclusão, edição e visualização são autoexplicativos no ambiente.

## Testes unitários

## Principais ferramentas e tecnologias

- Ubuntu 20.04.4 LTS
- .NET 6.0
- Entity Framework
- SQLite
- Moq
- XUnit
- NuGet
- Coverlet

## Observações

- Controle dos arquivos versionados com [.gitignore](.gitignore)
- Assinatura de commits com GPG
- Commit Semântico