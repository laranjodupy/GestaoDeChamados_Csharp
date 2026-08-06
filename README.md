# 🎫 Sistema de Gestão de Chamados

Sistema desktop de gerenciamento de chamados técnicos, desenvolvido em **C#** com **Windows Forms**. Projeto acadêmico criado com o objetivo principal de praticar **.NET** e consolidar conceitos de **Programação Orientada a Objetos (POO)**.

## 📋 Sobre o Projeto

Empresas de suporte técnico precisam de um jeito organizado de não perder solicitações de clientes. Este sistema permite cadastrar clientes e atendentes, abrir chamados técnicos e acompanhar o status de cada um, com um sistema de **login e permissões por papel de usuário**.

O projeto começou simples (dados em memória) e foi evoluindo — hoje já persiste tudo em um banco **SQLite** local e trata autenticação com **hash de senha (BCrypt)**.

## 🚀 Funcionalidades

- ✅ Login com autenticação e senha criptografada (hash)
- ✅ Controle de acesso por papel de usuário (Admin, Operador, Visualizador)
- ✅ Cadastrar e listar clientes (nome e contato)
- ✅ Cadastrar e listar atendentes (nome e setor)
- ✅ Abrir chamados informando cliente, atendente e descrição
- ✅ Alterar status do chamado: `Aberto` → `Em Andamento` → `Resolvido`
- ✅ Validações de formulário (campos obrigatórios, cliente/atendente selecionado)
- ✅ Contador em tempo real de chamados abertos e em andamento
- ✅ Persistência dos dados em banco SQLite local (nada se perde ao fechar o programa)

## 🛠️ Tecnologias

- **C# / .NET 10** — linguagem e plataforma principal
- **Windows Forms** — interface gráfica desktop
- **SQLite** (via `Microsoft.Data.Sqlite`) — banco de dados local, criado automaticamente na primeira execução
- **BCrypt.Net-Next** — hash seguro de senhas
- **Visual Studio Community 2022** — IDE utilizada no desenvolvimento
- **Git + GitHub** — versionamento

## 🗂️ Estrutura do Projeto

```
sistema-gestao-chamados/
├── Data/
│   └── Database.cs               → Conexão e criação/seed do banco SQLite
├── Forms/
│   ├── FormLogin.cs              → Tela de autenticação
│   ├── Form1.cs                  → Tela principal (menu, contadores, permissões)
│   ├── FormCliente.cs            → Cadastro e listagem de clientes
│   ├── FormAtendente.cs          → Cadastro e listagem de atendentes
│   └── FormChamado.cs            → Abertura, listagem e alteração de status de chamados
├── Models/
│   ├── Cliente.cs                → Entidade Cliente
│   ├── Atendente.cs              → Entidade Atendente
│   ├── Chamado.cs                → Entidade Chamado
│   ├── Usuario.cs                → Entidade Usuário do sistema
│   ├── Papel.cs                  → Enum com os papéis de usuário (Admin, Operador, Visualizador)
│   ├── Permissao.cs              → Enum com as permissões possíveis do sistema
│   └── PermissionService.cs      → Regras de quais papéis têm quais permissões
├── Repositories/
│   ├── ClienteRepository.cs      → Acesso a dados (CRUD) de Cliente
│   ├── AtendenteRepository.cs    → Acesso a dados (CRUD) de Atendente
│   ├── ChamadoRepository.cs      → Acesso a dados (CRUD) de Chamado
│   └── UsuarioRepository.cs      → Acesso a dados de Usuário
├── Services/
│   ├── AuthService.cs            → Login, logout e checagem de permissão da sessão atual
│   ├── SecurityService.cs        → Geração e verificação de hash de senha (BCrypt)
│   └── Sessao.cs                 → Guarda o usuário logado durante a execução
├── Program.cs                    → Ponto de entrada da aplicação
└── .gitignore
```

## 🧠 Conceitos de POO Aplicados

### Classes e Objetos
Cada entidade do domínio virou uma classe com responsabilidade bem definida: `Cliente`, `Atendente`, `Chamado` e `Usuario`.

### Encapsulamento
As propriedades usam `get`/`set` para controlar o acesso aos dados. O `Id` de cada entidade usa `private set` — só a própria classe pode definir seu identificador:

```csharp
public int Id { get; private set; }  // Lê de qualquer lugar, mas só muda internamente
public string Nome { get; set; }     // Lê e escreve de qualquer lugar
```

O mesmo vale para o `Status` de um `Chamado`, que só muda através do método `AlterarStatus()`, nunca diretamente.

### Construtores
Os objetos de domínio nascem sempre com dados válidos e completos:

```csharp
public Cliente(int id, string nome, string contato)
{
    Id = id;
    Nome = nome;
    Contato = contato;
}
```

### Herança e Override
Todos os formulários herdam de `Form` (Windows Forms). O método `ToString()` é sobrescrito nos models para exibir dados legíveis em `ComboBox`:

```csharp
public override string ToString()
{
    return $"{Id} - {Nome}"; // Exibe "1 - João Silva" no ComboBox
}
```

### Enums
`Papel` (Admin, Operador, Visualizador) e `Permissao` (AbrirChamado, ExcluirCliente, GerenciarUsuarios, etc.) usam `enum` para representar conjuntos fixos de valores de forma segura em tempo de compilação.

### Separação de Responsabilidades (arquitetura em camadas)
O projeto é dividido em camadas com responsabilidades claras:

- **Models** → representam as entidades e regras de domínio
- **Repositories** → cuidam do acesso ao banco de dados (SQL puro com parâmetros, protegido contra SQL Injection)
- **Services** → concentram regras de negócio (autenticação, segurança, permissões, sessão)
- **Forms** → cuidam apenas da interface e conectam tudo

Isso significa, por exemplo, que `Cliente` não sabe nada sobre `Chamado`; um `Chamado` recebe objetos `Cliente` e `Atendente` já prontos, em vez de criá-los.

### Métodos estáticos e classes utilitárias
`AuthService`, `SecurityService` e `PermissionService` são classes estáticas — não fazem sentido como instâncias, pois representam operações e regras que não dependem de estado próprio (exceto a `Sessao`, que guarda o usuário logado durante a execução do programa).

## 🔐 Autenticação e Permissões

O sistema possui 3 papéis de usuário, cada um com um conjunto de permissões pré-definido em `PermissionService`:

| Papel | Acesso |
|---|---|
| **Admin** | Acesso total, incluindo gerenciamento de usuários |
| **Operador** | Acesso a clientes, atendentes e chamados (sem gerenciar usuários) |
| **Visualizador** | Apenas listagem/consulta (somente leitura) |

As senhas nunca são salvas em texto puro — são armazenadas como hash gerado pelo **BCrypt**.

Na primeira execução, o banco é criado automaticamente e um usuário administrador padrão é gerado:

```
Login: admin
Senha: admin123
```

> 💡 Recomenda-se trocar essa senha (ou criar um novo usuário Admin e remover o padrão) antes de qualquer uso além de testes locais.

## 🖥️ Como Rodar

### Pré-requisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/) (ou o Visual Studio 2022 mais recente, que já inclui o SDK)
- Windows (o projeto usa Windows Forms, que é específico da plataforma)

### Passo a passo

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/sistema-gestao-chamados.git
   ```
2. Abra a pasta no **Visual Studio Community 2022** (ou mais recente).
3. Restaure os pacotes NuGet (o Visual Studio costuma fazer isso automaticamente ao abrir).
4. Pressione **F5** ou clique em **Iniciar** — o banco SQLite (`chamados.db`) é criado automaticamente na primeira execução, junto com o usuário administrador padrão.
5. Faça login com `admin` / `admin123` e explore o sistema.

## 🎨 Design

Interface em modo escuro (dark mode), com botões coloridos por seção para facilitar a navegação:

- 🔵 **Azul** — Clientes
- 🟢 **Verde** — Atendentes
- 🔴 **Vermelho** — Chamados

## 📚 O que foi praticado

| Conceito | Onde foi aplicado |
|---|---|
| Classes e Objetos | `Cliente`, `Atendente`, `Chamado`, `Usuario` |
| Encapsulamento | `private set` no `Id` de todas as entidades e no `Status` de `Chamado` |
| Construtores | Garantem que os objetos sempre nascem completos e válidos |
| Herança | Formulários herdando de `Form` |
| `override ToString()` | Exibição legível nos `ComboBox` |
| Enums | `Papel` e `Permissao` |
| Separação de responsabilidades | Camadas Models / Repositories / Services / Forms |
| Persistência de dados | SQLite + ADO.NET (`Microsoft.Data.Sqlite`), com queries parametrizadas |
| Segurança | Hash de senha com BCrypt, controle de acesso por papel |
| Windows Forms | Designer, eventos de botão, `DataGridView`, `ComboBox`, `ShowDialog()` |

## 🚧 Possíveis próximos passos

- Implementar telas de gerenciamento de usuários (criar/editar/remover usuários e papéis) pela interface, hoje só existe via seed inicial
- Adicionar edição e exclusão de chamados/clientes/atendentes nas telas onde ainda falta
- Extrair as regras que estão nos `Forms` para as classes `Service` correspondentes (`ClienteService` e `ChamadoService` já existem como esqueleto, mas ainda não são usadas)
- Testes automatizados para `Repositories` e `Services`

## 📄 Licença

Projeto desenvolvido para fins acadêmicos, com foco no aprendizado de C#, .NET e Programação Orientada a Objetos.
