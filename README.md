
# Todo List

Api constru�da utilizando .NET 6, Entity Framework Core (SQLServer) para o cadastro de tarefas.
A aplica��o oferece recursos b�sicos de uma API (GET, PUT, POST, DELETE)  


## Autor

- [@eaiigor](https://www.linkedin.com/in/igor-rocha-lima/) - Igor Rocha Lima


## Arquitetura

- Domain Driven Design (DDD)

A aplica��o segue os conceitos de DDD

**Domain**  
Na camada de dom�nio temos as entidades da aplica��o.

**Infrastructure**  
Na camada de infraestrutura temos a defini��o dos reposit�rios e o contexto do banco de dados.

**Controllers**  
J� na camada de apresenta��o temos todos os controllers.

**Application**  
Nesta camada est�o os itens que n�o est�o diretamente relacionados �s principais camadas do DDD. Aqui est� localizado os Comandos, Handlers e Queries da aplica��o, 
seguindo os conceitos de CQRS

## Instala��o e Execu��o

Para rodar a aplica��o utilize o Visual Studio em conjunto do .NET 6.

## Banco de Dados

Foi utilizado de ORM o Entity Framework Core junto do SQLServer.

1- Crie uma vari�vel de ambiente chamada CONN_STR seguindo o modelo

`Data Source=R31D\\SQLEXPRESS;Initial Catalog=ESG_DB;Integrated Security=False;User ID=USERNAME;Password=PWD;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False`

Substitua USERNAME por seu usu�rio e PWD pela senha de seu servidor sql server.

2- Certifique que voc� est� no projeto da aplica��o (se estiver na raiz do projeto, o database update n�o vai funcionar)

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
- Aplica��o dos conceitos de **DDD** e **CQRS**

### EF Core

O EF Core foi configurado em `Infrastructure\Data\ApiDbContext.cs`