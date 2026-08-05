# OrdemTech — Gestão de Ordens de Serviço (ASP.NET Core MVC)

<div align="center">

<!-- Animação Typing SVG -->
<a href="https://git.io/typing-svg">
  <img src="https://readme-typing-svg.demolab.com?font=Fira+Code&weight=600&size=24&pause=1000&color=0078D4&center=true&vCenter=true&width=600&lines=Sistema+de+Gest%C3%A3o+de+Clientes+e+Ordens+de+Servi%C3%A7o;Desenvolvido+em+C%23+%2B+ASP.NET+Core+MVC;Persist%C3%Aancia+com+Entity+Framework+Core" alt="Typing SVG" />
</a>

<br/><br/>

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-blue?style=for-the-badge)
![EF Core](https://img.shields.io/badge/Entity%20Framework-Core-purple?style=for-the-badge)

</div>

---

## Sobre o Projeto

O **OrdemTech** é uma aplicação web full-stack voltada para o gerenciamento de clientes e ordens de serviço. Desenvolvido no padrão arquitetural **MVC (Model-View-Controller)** com **ASP.NET Core**, o sistema aplica **DataAnnotations** para validação robusta de formulários e utiliza o **Entity Framework Core** para abstração da camada de dados e gerenciamento de migrações no banco de dados.

---

## Funcionalidades

- **Gestão de Clientes**: Cadastro, listagem, edição e remoção de clientes com validação de campos (nome, e-mail e telefone).
- **Gestão de Ordens de Serviço**: Controle de chamados e serviços atrelados a cada cliente (Relacionamento 1:N).
- **Validação de Dados**: Regras de validação Server-Side e Client-Side garantindo a integridade das informações prestadas.
- **Mapeamento de Banco de Dados**: Versionamento de esquema via **EF Core Migrations**.

---

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework Web**: ASP.NET Core MVC
- **ORM**: Entity Framework Core (`ApplicationDbContext`)
- **Estilização & Frontend**: Razor Views, HTML5, CSS3, JavaScript (diretório `wwwroot`)
- **Versionamento de BD**: EF Core Migrations
- **IDE**: Visual Studio / Visual Studio Code

---

## Arquitetura do Projeto

```text
ordemtech-mvc-csharp/
 ├── Controllers/             # Controladores responsáveis pelas rotas e regras da aplicação
 ├── Models/                  # Modelos de domínio e validação (Cliente.cs, OrdemServico.cs)
 ├── Views/                   # Interfaces gráficas dinâmicas em Razor (.cshtml)
 ├── Migrations/              # Histórico de migrações do banco de dados (EF Core)
 ├── wwwroot/                 # Arquivos estáticos (CSS, JS, bibliotecas frontend)
 ├── ApplicationDbContext.cs  # Contexto de conexão e mapeamento do ORM
 ├── Program.cs               # Configuração de serviços e pipeline HTTP
 └── appsettings.json         # Configurações de ambiente e strings de conexão
 Fluxo da Aplicação
Plaintext
+-----------------------------------------------------------------------+
|                             INÍCIO                                    |
|                      (Requisição HTTP / Web)                          |
+-----------------------------------------------------------------------+
                                   |
                                   v
+-----------------------------------------------------------------------+
|                      Roteamento ASP.NET Core                          |
|                     (Controller selecionado)                          |
+-----------------------------------------------------------------------+
                                   |
                                   v
+-----------------------------------------------------------------------+
|                   Validação de Dados (ModelState)                     |
|                   - DataAnnotations em Cliente.cs                     |
+-----------------------------------------------------------------------+
                 /                                       \
       [Dados Inválidos]                           [Dados Válidos]
               /                                           \
              v                                             v
+---------------------------+             +-----------------------------+
| Retorna View com Erros    |             | Processa as Regras de      |
| (Exibe mensagens na tela) |             | Negócio no Controller       |
+---------------------------+             +-----------------------------+
              |                                          |
              v                                          v
+-----------------------------------------------------------------------+
|                    Renderização da Response (Razor View)              |
+-----------------------------------------------------------------------+
                                   |
                                   v
+-----------------------------------------------------------------------+
|                              FIM                                      |
+-----------------------------------------------------------------------+
```
Como Executar
Pré-requisitos
.NET SDK instalado (versão 6.0 ou superior).

Passo a Passo
Clonar o repositório:

Bash
git clone [https://github.com/andredejesus-dev/ordemtech-mvc-csharp.git](https://github.com/andredejesus-dev/ordemtech-mvc-csharp.git)
Acessar o diretório do projeto:

Bash
cd ordemtech-mvc-csharp
Restaurar as dependências:

Bash
dotnet restore
Executar a aplicação:

Bash
dotnet run
Acesse a URL indicada no terminal (ex: https://localhost:7001 ou http://localhost:5000).
Feito por : André de Jesus
