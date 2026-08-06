using GestaoChamados.Models;
using GestaoChamados.Repositories;
using GestaoChamados.Services;

namespace GestaoChamados.Forms
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

            if (usuario == null)
                return;

            this.Text =
                $"Sistema de Chamados — {usuario.Name} ({usuario.Papel})";

            btnClientes.Enabled =
                PermissionService.TemPermissao(
                    usuario.Papel,
                    Permissao.ListarClientes);

            btnAtendentes.Enabled =
                PermissionService.TemPermissao(
                    usuario.Papel,
                    Permissao.ListarAtendentes);

            btnChamados.Enabled =
                PermissionService.TemPermissao(
                    usuario.Papel,
                    Permissao.ListarChamados);
        }

        private void AtualizarContador()
        {
            int abertos = chamados.Count(c => c.Status == "Aberto");
            int emAndamento = chamados.Count(c => c.Status == "Em Andamento");
            lblContador.Text = $"tem {abertos} baguios abertos   & {emAndamento} mizeras em andamento";
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            if (!PermissionService.TemPermissao(
                Sessao.UsuarioAtual.Papel,
                Permissao.ListarClientes))
            {
                MessageBox.Show("Acesso negado.");
                return;
            }

            new FormCliente(clientes).ShowDialog();
            clientes = _clienteRepo.BuscarTodos(); // Recarrega do banco
            AtualizarContador();
        }

        private void btnAtendentes_Click(object sender, EventArgs e)
        {
            if (!PermissionService.TemPermissao(
                Sessao.UsuarioAtual.Papel,
                Permissao.ListarAtendentes))
            {
                MessageBox.Show("Acesso negado.");
                return;
            }

            new FormAtendente(atendentes).ShowDialog();

            atendentes = _atendenteRepo.BuscarTodos();
            AtualizarContador();
        }

        private void btnChamados_Click(object sender, EventArgs e)
        {
            if (!PermissionService.TemPermissao(
                Sessao.UsuarioAtual.Papel,
                Permissao.ListarChamados))
            {
                MessageBox.Show("Acesso negado.");
                return;
            }

            new FormChamado(chamados, clientes, atendentes).ShowDialog();

            chamados = _chamadoRepo.BuscarTodos();
            AtualizarContador();
        }
    }
}