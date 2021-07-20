# .NET Ifood API

## Sobre

Esta é uma API RESTful desenvolvida em ASP.NET Core, utilizando Entity Framework Core, Injeção de dependências seguindo os princípios do SOLID e Clean Code, autenticação por JWT. Este repositório não possui intuito comercial e é destinado apenas como portfólio e objeto de estudos

A finalidade do mesmo é simular as requisições da plataforma IFood para recuperar, filtrar, adicionar e atualizar restaurantes, produtos e pedidos.

## Configuração

- Instalar EF Core

```
dotnet tool install --global dotnet-ef
```

- Atualizar connection string no arquivo appsettings.json

```
"ConnectionStrings": {
    "Postgres": "Server=ec2-18-211-97-89.compute-1.amazonaws.com;Port=___;Database=_______________;User Id=_______________;Password=_______________;SslMode=Require;Trust Server Certificate=true"
  },
```

- Adicionar migrations

```
dotnet-ef migrations add <migration-name>
```

- Aplicar Migrations

```
dotnet ef database update
```

- Criar imagem Docker

```
sudo docker build -t deep/wefood.api:1 .
```

- Executar docker

```
sudo docker run -p 8080:3000 deep/wefood.api:1
```

## RESTful URLs

| HTTP METHOD   | POST              | GET                   | PUT               | DELETE         |
| ------------- | ----------------- | --------------------- | ----------------- | -------------- |
| CRUD OP       | UPDATE            | READ                  | CREATE            | DELETE         |
| /auth      | N/A               | Recuperar token JWT    | N/A               | N/A            |
| /company      | N/A               | Recuperar empresas    | N/A               | N/A            |
| /company/1234 | Atualizar Empresa | Recuperar uma empresa | Atualizar Empresa | Remove Empresa |
| /company/1234/product | N/A               | Recuperar produtos de uma empresa     | N/A  | N/A            |
| /order        | N/A               | Recuperar pedidos     | Adicionar Pedido  | N/A            |
| /order/1234   | Atualizar Pedido  | Recuperar uma empresa | N/A               | Remover Pedido |
| /product   | N/A  | N/A | Adicionar produto               | N/A |
| /product/1234   | Atualizar Produto  | Recuperar produto | N/A               | Remover Produto |
| /user   | Atualizar usuário autenticado  | Recuperar usuário autenticado | N/A               | N/A |

(Example from Web API Design, by Brian Mulloy, Apigee.)



