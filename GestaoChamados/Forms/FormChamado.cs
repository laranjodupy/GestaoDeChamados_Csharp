using GestaoChamados.Models;
using GestaoChamados.Repositories;
using GestaoChamados.Services;

namespace GestaoChamados.Forms
{
    public partial class FormChamado : Form
    {
        private List<Chamado> chamados;
        private List<Cliente> clientes;
        private List<Atendente> atendentes;
        private readonly ChamadoRepository _repo = new();

        public FormChamado(List<Chamado> chamados, List<Cliente> clientes, List<Atendente> atendentes)
        {
            InitializeComponent();
            this.chamados = chamados;
            this.clientes = clientes;
            this.atendentes = atendentes;
            CarregarCombos();
            AplicarPermissoes();
            AtualizarLista();
        }

        private void CarregarCombos()
        {
            cmbClientes.DataSource = null;
            cmbClientes.DataSource = clientes.ToList();
            cmbAtendentes.DataSource = null;
            cmbAtendentes.DataSource = atendentes.ToList();
        }

        private void AplicarPermissoes()
        {
            bool podeEditar = AuthService.TemPermissao(Permissao.AbrirChamado);
            btnAbrir.Enabled = podeEditar;
            btnAlterarStatus.Enabled = AuthService.TemPermissao(Permissao.AlterarStatusChamado);
            txtDescricao.ReadOnly = !podeEditar;
            if (!podeEditar) btnAbrir.Text = "🔒 Sem permissão";
        }

        private string[] mensagensAbertura = {
            "Mais um problemão, bora lá 💪",
            "Chamado aberto, Deus abençoe o atendente 🙏",
            "Lá vem mais trabalho... bora! 😅",
            "Anotado chefe, vamos resolver essa parada! 📝",
            "Chamado registrado! O atendente já tá sofrendo 😂"
        };

        private string[] mensagensResolucao = {
            "RESOLVIDO! Bora comemorar ☕",
            "Finalmente! Isso sim é trabalho bem feito 🏆",
            "Problema no chinelo! Resolvido! 😎",
            "GG EZ! Chamado resolvido! 🎮",
            "Mais um pro currículo! Resolvido! 🚀"
        };

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (clientes.Count == 0)
            {
                MessageBox.Show("Cadastra um cliente primeiro! 😂", "Ops!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (atendentes.Count == 0)
            {
                MessageBox.Show("Cadastra um atendente primeiro! 👑", "Ops!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (cmbClientes.SelectedItem == null || cmbAtendentes.SelectedItem == null
                || string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("Preenche todos os campos mano! 🙄", "Campos vazios",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            var cliente = (Cliente)cmbClientes.SelectedItem;
            var atendente = (Atendente)cmbAtendentes.SelectedItem;
            // Id=0 — banco gera o Id real
            _repo.Inserir(new Chamado(0, txtDescricao.Text.Trim(), cliente, atendente));
            chamados = _repo.BuscarTodos();
            AtualizarLista();
            txtDescricao.Clear();

            var rng = new Random();
            MessageBox.Show(mensagensAbertura[rng.Next(mensagensAbertura.Length)],
                "Chamado Aberto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAlterarStatus_Click(object sender, EventArgs e)
        {
            if (dgvChamados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleciona um chamado! 👆", "Nada selecionado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            var selecionado = (Chamado)dgvChamados.SelectedRows[0].DataBoundItem;
            string novoStatus = cmbStatus.SelectedItem!.ToString()!;

            _repo.AtualizarStatus(selecionado.Id, novoStatus);
            chamados = _repo.BuscarTodos();
            AtualizarLista();

            if (novoStatus == "Resolvido")
            {
                var rng = new Random();
                MessageBox.Show(mensagensResolucao[rng.Next(mensagensResolucao.Length)],
                    "🎉 Resolvido!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AtualizarLista()
        {
            dgvChamados.DataSource = null;
            dgvChamados.DataSource = chamados.ToList();
        }
    }
}