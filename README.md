
# Todo List

Api construída utilizando .NET 6, Entity Framework Core (SQLServer) para o cadastro de tarefas.
A aplicação oferece recursos básicos de uma API (GET, PUT, POST, DELETE)  


## Autor

- [@eaiigor](https://www.linkedin.com/in/igor-rocha-lima/) - Igor Rocha Lima


## Arquitetura

- Domain Driven Design (DDD)

A aplicação segue os conceitos de DDD

**Domain**  
Na camada de domínio temos as entidades da aplicação.

**Infrastructure**  
Na camada de infraestrutura temos a definição dos repositórios e o contexto do banco de dados.

**Controllers**  
Já na camada de apresentação temos todos os controllers.

**Application**  
Nesta camada estão os itens que não estão diretamente relacionados às principais camadas do DDD. Aqui está localizado os Comandos, Handlers e Queries da aplicação, 
seguindo os conceitos de CQRS

## Instalação e Execução

Para rodar a aplicação utilize o Visual Studio em conjunto do .NET 6.

## Banco de Dados

Foi utilizado de ORM o Entity Framework Core junto do SQLServer.

1- Crie uma variável de ambiente chamada CONN_STR seguindo o modelo

`Data Source=R31D\\SQLEXPRESS;Initial Catalog=ESG_DB;Integrated Security=False;User ID=USERNAME;Password=PWD;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False`

Substitua USERNAME por seu usuário e PWD pela senha de seu servidor sql server.

2- Certifique que você está no projeto da aplicação (se estiver na raiz do projeto, o database update não vai funcionar)

```bash
$cd ESGENDPOINTS
```

3- Instale o EF Core global com o dotnet.

```bash
$dotnet tool install --global dotnet-ef --version=6.0.32
```

4- Rode o update utilizando o EF core.

```bash
$dotnet ef database update
```

## Diferenciais

- Foi utilizado o **EF Core** como ORM
- Aplicação dos conceitos de **DDD** e **CQRS**

### EF Core

O EF Core foi configurado em `Infrastructure\Data\ApiDbContext.cs`