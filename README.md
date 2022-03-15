
# Gerenciador de Lugares
## 💡 Sobre o Projeto

Uma API para gerenciamento de squad onde você consegue cadastrar pessoas ao seu squad, definir e editar tasks.

## 🚀 Tecnologias utilizadas

O projeto foi desenvolvido utilizando as seguintes tecnologias:

- C#
- .NET 6
- EntityFramework
- Swagger
- SQLServer

## 📑 Documentação da API
## Usuário
#### Cadrastro de usuário

```http
  POST /Api/user
```
| Body   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Name`      | `string` | **Obrigatório**|
| `Email`      | `string` | **Obrigatório**|
| `Password`      | `string` | **Obrigatório**|

#### Auth(Login)

```http
   POST /Api/auth
```

| Body   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Email`      | `string` | **Obrigatório**|
| `Password`      | `string` | **Obrigatório**|

#### Agora você precisa do token gerado pelo Login para acessar os endpoints (Bearer Token)
#### Listar usuários

```http
  GET /Api/user
```
#### Listar usuario pelo id
```http
  GET /Api/user/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório** |

#### Editar um usuario
```http
  PUT /Api/user/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `Int` | **Obrigatório**|

| Body   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Name`      | `string` | **Obrigatório**|
| `Email`     | `string` | **Obrigatório**|
| `Password`  | `string` | **Obrigatório**|

#### Exclui um usuario
```http
  DELETE /Api/user/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `Int` | **Obrigatório**|


## Squad
#### Listar todos os squads
```http
  GET /Api/squad
```
#### Listar squad pelo id
```http
  GET /Api/squad/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório** |

#### Cadrastro de Squad

```http
  POST /Api/squad
```
| Body   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Name`      | `string` | **Obrigatório**|

#### Editar um squad
```http
  PUT /Api/squad/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `Int` | **Obrigatório**. O Id do lugar que você quer editar|

| Body   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Name`      | `string` | **Obrigatório**.|
| `Leader`     | `string` | **Obrigatório**.|


#### Exclui um squad
```http
  DELETE /Api/squad/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `Int` | **Obrigatório**|

## Task
#### Listar todas as tarefas
```http
  GET /Api/task
```
#### Listar tarefas pelo id
```http
  GET /Api/task/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório** |

#### Cadrastro de tarefas

```http
  POST /Api/task
```
| Body   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Name`      | `string` | **Obrigatório**|
| `Title`      | `string` | **Obrigatório**|
| `Description`      | `string` | **Obrigatório**|
| `Deadline`      | `datetime` | **Obrigatório**|
| `Squad_id`      | `int` | **Obrigatório**|


#### Editar uma tarefa
```http
  PUT /Api/task/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `Int` | **Obrigatório**. O Id do lugar que você quer editar|

| Body   | Tipo       | 
| :---------- | :--------- |
| `Name`      | `string` | 
| `Title`      | `string` | 
| `Description`      | `string` | 
| `Deadline`      | `datetime` |
| `Squad_id`      | `int` | **Obrigatório**|

#### Exclui um tarefa
```http
  DELETE /Api/task/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `Int` | **Obrigatório**|


## Person
#### Listar todas as pessoas
```http
  GET /Api/person
```
#### Listar pessoas pelo id
```http
  GET /Api/person/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório** |

#### Cadrastro de pessoas

```http
  POST /Api/person
```
| Body   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `user_id`      | `int` | **Obrigatório**|
| `squad_id`      | `int` | **Obrigatório**|



#### Editar uma pessoa
```http
  PUT /Api/person/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `Int` | **Obrigatório**. O Id do lugar que você quer editar|

| Body   | Tipo       | 
| :---------- | :--------- |
| `user_id`      | `int` | **Obrigatório**|
| `squad_id`      | `int` | **Obrigatório**|


#### Exclui uma pessoa
```http
  DELETE /Api/person/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `Int` | **Obrigatório**|



## 📥 Executar esse projeto no seu computador

- Clonar Repositório: `git clone https://github.com/guilhermetj/Gerenciador_Lugares.git`

- Subir as tabelas do banco de dados: `dotnet ef database update`
- Rodar Aplicação: `dotnet run`
