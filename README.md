# Sistema Academia Boxe

## Descrição do Projeto

O Sistema Academia Boxe é uma aplicação web desenvolvida para gerenciamento de alunos e professores de uma academia de boxe.

O sistema permite:

* Cadastro de alunos
* Cadastro de professores
* Edição de alunos e professores
* Exclusão de alunos e professores
* Pesquisa dinâmica sem recarregar a página
* Relacionamento entre alunos e professores
* Modelagem documental utilizando MongoDB

O projeto foi desenvolvido utilizando ASP.NET Core Web API no backend, MongoDB Atlas como banco de dados e HTML/CSS/JavaScript no frontend.

---

# Tecnologias Utilizadas

* C#
* ASP.NET Core Web API
* MongoDB Atlas
* HTML
* CSS
* JavaScript
* Swagger
* Live Server

---

# Pré-requisitos

É necessário ter instalado:

* .NET SDK compatível com o projeto
* Visual Studio Code ou Visual Studio
* Conta no MongoDB Atlas
* Navegador Web
* Extensão Live Server no VS Code

---

## Relacionamento entre Entidades

O sistema possui relacionamento entre alunos e professores.

A relação conceitual utilizada é de 1 para N:

* Um professor pode possuir vários alunos.
* Um aluno possui apenas um professor responsável.

Como o MongoDB o relacionamento foi modelado utilizando documento embutido.

No cadastro de alunos, o sistema realiza uma busca dos professores cadastrados na API e exibe esses professores em um campo de seleção (`select`) no frontend.

O usuário seleciona manualmente o professor responsável pelo aluno durante o cadastro.

Ao salvar um aluno, o sistema armazena um objeto `Professor` dentro do próprio documento do aluno, contendo dados básicos do professor responsável, como:

* Id
* Nome
* Especialidade

A collection de professores continua existindo para permitir o cadastro, edição, listagem e exclusão dos professores. Já no documento do aluno, é armazenado um resumo do professor selecionado.

---


## Exemplo de Estrutura

```json
{
  "nome": "João",
  "email": "joao@email.com",
  "telefone": "99999-9999",
  "professor": {
    "id": "id-do-professor",
    "nome": "Professor Exemplo",
    "especialidade": "Boxe"
  }
}
```

---

# Como Executar o Projeto

## 1. Clone o repositório

```bash
git clone https://github.com/MatheusCesarMC/academia-boxe-api.git
```

---

## 2. Abra o projeto

Abra a pasta do projeto no Visual Studio Code ou no Visual Studio.

---

## 3. Configure o appsettings.Development.json

Adicione sua string de conexão MongoDB no arquivo `appsettings.Development.json`.

Exemplo:

```json
{
  "MongoDbSettings": {
    "ConnectionString": "SUA_STRING_DE_CONEXAO",
    "DatabaseName": "academia"
  }
}
```

---

## 4. Execute a API

No terminal, execute:

```bash
dotnet run
```

A API será iniciada em:

```text
http://localhost:5126
```

---

# Swagger

Após executar a API, acesse:

```text
http://localhost:5126/swagger
```

Use o Swagger para testar os endpoints da aplicação.

---

# Frontend

Para executar o frontend:

1. Abra a pasta `frontend`
2. Clique com o botão direito no arquivo `index.html`
3. Selecione **Open with Live Server**

---

# Funcionalidades

## Alunos

* Criar aluno
* Listar alunos
* Editar aluno
* Excluir aluno
* Pesquisar aluno por nome, email, telefone ou professor

## Professores

* Criar professor
* Listar professores
* Editar professor
* Excluir professor
* Pesquisar professor por nome, especialidade, email ou telefone

---