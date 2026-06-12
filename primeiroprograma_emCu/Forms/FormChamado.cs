using primeiroprograma_emCu.Models;

namespace primeiroprograma_emCu.Forms
{
    public partial class FormChamado : Form
    {
        private List<Chamado> chamados;
        private List<Cliente> clientes;
        private List<Atendente> atendentes;
        private int proximoId = 1;

        public FormChamado(List<Chamado> chamados, List<Cliente> clientes, List<Atendente> atendentes)
        {
            InitializeComponent();
            this.chamados = chamados;
            this.clientes = clientes;
            this.atendentes = atendentes;
            CarregarCombos();
            AtualizarLista();
        }

        private void CarregarCombos()
        {
            cmbClientes.DataSource = null;
            cmbClientes.DataSource = clientes.ToList();

            cmbAtendentes.DataSource = null;
            cmbAtendentes.DataSource = atendentes.ToList();
        }
        // Array de mensagens pra animar o trampo
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
                MessageBox.Show("Eita, cadastra um cliente primeiro meu consagrado! 😂", "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (atendentes.Count == 0)
            {
                MessageBox.Show("Sem atendente disponível meu rei, cadastra um lá! 👑", "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbClientes.SelectedItem == null || cmbAtendentes.SelectedItem == null || string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("Preenche todos os campos mano! 🙄", "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente cliente = (Cliente)cmbClientes.SelectedItem;
            Atendente atendente = (Atendente)cmbAtendentes.SelectedItem;
            Chamado novo = new Chamado(proximoId++, txtDescricao.Text, cliente, atendente);
            chamados.Add(novo);
            AtualizarLista();
            txtDescricao.Clear();

            // Mensagem aleatória
            var rng = new Random();
            MessageBox.Show(mensagensAbertura[rng.Next(mensagensAbertura.Length)], "Chamado Aberto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAlterarStatus_Click(object sender, EventArgs e)
        {
            if (dgvChamados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleciona um chamado aí meu chapa! 👆", "Nada selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Chamado selecionado = (Chamado)dgvChamados.SelectedRows[0].DataBoundItem;
            selecionado.AlterarStatus(cmbStatus.SelectedItem.ToString());
            AtualizarLista();

            // Mensagem só quando resolver
            if (cmbStatus.SelectedItem.ToString() == "Resolvido")
            {
                var rng = new Random();
                MessageBox.Show(mensagensResolucao[rng.Next(mensagensResolucao.Length)], "🎉 Resolvido!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void AtualizarLista()
        {
            dgvChamados.DataSource = null;
            dgvChamados.DataSource = chamados.ToList();
        }
    }
}