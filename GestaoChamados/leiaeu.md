🎫 Gestão de Chamados

Sistema desktop de gerenciamento de chamados técnicos, desenvolvido em C# com Windows Forms no Visual Studio Community. Projeto acadêmico com foco em Programação Orientada a Objetos (POO).


📋 Sobre o Projeto

Empresas de suporte técnico precisam de um sistema para não perderem solicitações. Esse sistema permite cadastrar clientes, atendentes, abrir chamados e acompanhar o status de cada um — tudo em memória, sem banco de dados.


🚀 Funcionalidades


✅ Cadastrar e listar clientes (nome e contato)
✅ Cadastrar e listar atendentes (nome e setor)
✅ Abrir chamados informando cliente, atendente e descrição
✅ Alterar status do chamado: Aberto → Em Andamento → Resolvido
✅ Validação de cliente duplicado
✅ Contador em tempo real de chamados abertos e em andamento
✅ Mensagens engraçadas pra animar o trampo 😂



🗂️ Estrutura do Projeto

GestaoChamados/
├── Forms/
│   ├── Form1.cs                  → Tela principal com menu
│   ├── Form1.Designer.cs         → Designer gerado da tela principal
│   ├── FormCliente.cs            → Cadastro e listagem de clientes
│   ├── FormCliente.Designer.cs   → Designer do formulário de clientes
│   ├── FormAtendente.cs          → Cadastro e listagem de atendentes
│   ├── FormAtendente.Designer.cs → Designer do formulário de atendentes
│   ├── FormChamado.cs            → Abertura, listagem e status de chamados
│   └── FormChamado.Designer.cs   → Designer do formulário de chamados
├── Models/
│   ├── Cliente.cs                → Classe que representa um cliente
│   ├── Atendente.cs              → Classe que representa um atendente
│   └── Chamado.cs                → Classe que representa um chamado
├── Program.cs                    → Ponto de entrada da aplicação
└── .gitignore                    → Arquivos ignorados pelo Git


🧠 Conceitos de POO Aplicados

Classes e Objetos

Cada entidade do sistema virou uma classe com responsabilidade bem definida:


Cliente — guarda nome e contato
Atendente — guarda nome e setor
Chamado — guarda descrição, status, e referências ao cliente e atendente


Encapsulamento

As propriedades usam get e set para controlar o acesso aos dados. O Id de cada classe usa private set — ou seja, só a própria classe pode definir seu Id, ninguém de fora muda.

csharppublic int Id { get; private set; } // Lê de qualquer lugar, mas só muda internamente
public string Nome { get; set; }    // Lê e escreve de qualquer lugar

Construtores

Todo objeto nasce com dados válidos — nenhum cliente, atendente ou chamado pode ser criado incompleto:

csharppublic Cliente(int id, string nome, string contato)
{
    Id = id;
    Nome = nome;
    Contato = contato;
}

Herança e Override

Todos os formulários herdam de Form (classe do Windows Forms). O método ToString() foi sobrescrito em cada model para exibir dados legíveis nos ComboBoxes:

csharppublic override string ToString()
{
    return $"{Id} - {Nome}"; // Exibe "1 - João Silva" no ComboBox
}

Separação de Responsabilidades

Cada classe cuida só do seu domínio:


Cliente não sabe nada sobre chamados
Chamado recebe cliente e atendente prontos — não os cria
Os formulários gerenciam as listas e conectam tudo



🏗️ Como as Classes se Relacionam

Form1
  ├── List<Cliente>      ─────────────► FormCliente
  ├── List<Atendente>    ─────────────► FormAtendente
  └── List<Chamado>      ─────────────► FormChamado
                                            ├── usa Cliente
                                            └── usa Atendente

Chamado
  ├── Cliente   (objeto completo, não só o Id)
  └── Atendente (objeto completo, não só o Id)

As listas vivem no Form1 e são passadas para os outros formulários — assim os dados persistem enquanto o programa estiver rodando.


📁 Detalhes das Classes

Cliente.cs

csharppublic class Cliente
{
    public int Id { get; private set; }
    public string Nome { get; set; }
    public string Contato { get; set; }

    public Cliente(int id, string nome, string contato) { ... }
    public override string ToString() => $"{Id} - {Nome}";
}

Atendente.cs

csharppublic class Atendente
{
    public int Id { get; private set; }
    public string Nome { get; set; }
    public string Setor { get; set; }

    public Atendente(int id, string nome, string setor) { ... }
    public override string ToString() => $"{Id} - {Nome}";
}

Chamado.cs

csharppublic class Chamado
{
    public int Id { get; private set; }
    public string Descricao { get; set; }
    public string Status { get; private set; } // Só muda via AlterarStatus()
    public Cliente Cliente { get; set; }
    public Atendente Atendente { get; set; }

    public Chamado(int id, string descricao, Cliente cliente, Atendente atendente)
    {
        Status = "Aberto"; // Nasce sempre como Aberto
        ...
    }

    public void AlterarStatus(string novoStatus) { Status = novoStatus; }
}


🖥️ Como Rodar


Clone o repositório:


bashgit clone https://github.com/seu-usuario/GestaoChamados.git


Abre no Visual Studio Community 2022
Aperta F5 ou clica em Iniciar — é só isso, sem configuração extra



💡 O projeto já vem com 2 clientes e 2 atendentes mockados para teste




🎨 Design

Interface dark mode com tema escuro (#1E1E28), botões coloridos por seção:


🔵 Azul — Clientes
🟢 Verde — Atendentes
🔴 Vermelho — Chamados



📚 O que Aprendi

Durante o desenvolvimento desse projeto, trabalhei na prática os seguintes conceitos:

ConceitoOnde foi aplicadoClasses e ObjetosCliente, Atendente, ChamadoEncapsulamentoprivate set no Id de todas as classesConstrutoresGarantem objetos sempre completosList<T>Armazenamento em memória das entidadesoverride ToString()Exibição nos ComboBoxesHerançaFormulários herdam de FormSeparação de ResponsabilidadesCada classe cuida do seu domínioWindows FormsDesigner, eventos de botão, DataGridView, ComboBox


🛠️ Tecnologias


C# .NET — Linguagem principal
Windows Forms — Interface gráfica
Visual Studio Community 2022 — IDE
Git + GitHub — Versionamento



Projeto desenvolvido como trabalho acadêmico de POO — 2026