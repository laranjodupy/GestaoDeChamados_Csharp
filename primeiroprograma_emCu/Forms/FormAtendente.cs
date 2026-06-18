using primeiroprograma_emCu.Models;
using primeiroprograma_emCu.Repositories;
using primeiroprograma_emCu.Services;

namespace primeiroprograma_emCu.Forms
{
    public partial class FormAtendente : Form
    {
        private List<Atendente> atendentes;
        private readonly AtendenteRepository _repo = new();

        public FormAtendente(List<Atendente> atendentes)
        {
            InitializeComponent();
            this.atendentes = atendentes;
            AplicarPermissoes();
            AtualizarLista();
        }

        private void AplicarPermissoes()
        {
            bool podeEditar = AuthService.TemPermissao(Permissao.CadastrarAtendente);
            btnCadastrar.Enabled = podeEditar;
            txtNome.ReadOnly = !podeEditar;
            txtSetor.ReadOnly = !podeEditar;
            if (!podeEditar) btnCadastrar.Text = "🔒 Sem permissão";
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtSetor.Text))
            {
                MessageBox.Show("Preenche nome e setor!", "Campos vazios",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _repo.Inserir(new Atendente(0, txtNome.Text.Trim(), txtSetor.Text.Trim()));
            atendentes = _repo.BuscarTodos();
            AtualizarLista();
            txtNome.Clear();
            txtSetor.Clear();
        }

        private void AtualizarLista()
        {
            dgvAtendentes.DataSource = null;
            dgvAtendentes.DataSource = atendentes.ToList();
        }
    }
}
