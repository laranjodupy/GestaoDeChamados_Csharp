using primeiroprograma_emCu.Models;
using primeiroprograma_emCu.Repositories;
using primeiroprograma_emCu.Services;

namespace primeiroprograma_emCu.Forms
{
    public partial class Form1 : Form
    {
        // Agora as listas vêm do banco, não são mais mockadas
        private List<Cliente> clientes = new();
        private List<Atendente> atendentes = new();
        private List<Chamado> chamados = new();

        private readonly ClienteRepository _clienteRepo = new();
        private readonly AtendenteRepository _atendenteRepo = new();
        private readonly ChamadoRepository _chamadoRepo = new();

        public Form1()
        {
            InitializeComponent();
            CarregarDados();
            AplicarPermissoes();
            AtualizarContador();
        }

        private void CarregarDados()
        {
            // Carrega tudo do banco na inicialização
            clientes = _clienteRepo.BuscarTodos();
            atendentes = _atendenteRepo.BuscarTodos();
            chamados = _chamadoRepo.BuscarTodos();
        }

        private void AplicarPermissoes()
        {
            var usuario = Sessao.UsuarioAtual;
            if (usuario == null) return;

            // Mostra o papel do usuário logado no título
            this.Text = $"Sistema de Chamados — {usuario.Name} ({usuario.Papel})";

            // Só Admin vê o botão de gerenciar usuários
            // (adicione um btnUsuarios no Designer e descomente)
            // btnUsuarios.Visible = usuario.Papel == Papel.Admin;
        }

        private void AtualizarContador()
        {
            int abertos = chamados.Count(c => c.Status == "Aberto");
            int emAndamento = chamados.Count(c => c.Status == "Em Andamento");
            lblContador.Text = $"tem {abertos} baguios abertos   & {emAndamento} mizeras em andamento";
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            new FormCliente(clientes).ShowDialog();
            clientes = _clienteRepo.BuscarTodos(); // Recarrega do banco
            AtualizarContador();
        }

        private void btnAtendentes_Click(object sender, EventArgs e)
        {
            new FormAtendente(atendentes).ShowDialog();
            atendentes = _atendenteRepo.BuscarTodos();
            AtualizarContador();
        }

        private void btnChamados_Click(object sender, EventArgs e)
        {
            new FormChamado(chamados, clientes, atendentes).ShowDialog();
            chamados = _chamadoRepo.BuscarTodos();
            AtualizarContador();
        }
    }
}