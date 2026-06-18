using primeiroprograma_emCu.Models;
using primeiroprograma_emCu.Repositories;
using primeiroprograma_emCu.Services;

namespace primeiroprograma_emCu.Forms
{
    public partial class FormCliente : Form
    {
        private List<Cliente> clientes;
        private readonly ClienteRepository _repo = new();

        public FormCliente(List<Cliente> clientes)
        {
            InitializeComponent();
            this.clientes = clientes;
            AplicarPermissoes();
            AtualizarLista();
        }

        private void AplicarPermissoes()
        {
            bool podeEditar = AuthService.TemPermissao(Permissao.CadastrarCliente);
            btnCadastrar.Enabled = podeEditar;
            txtNome.ReadOnly = !podeEditar;
            txtContato.ReadOnly = !podeEditar;
            if (!podeEditar) btnCadastrar.Text = "🔒 Sem permissão";
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtContato.Text))
            {
                MessageBox.Show("Preenche nome e contato meu rei! 👑", "Campos vazios",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool duplicado = clientes.Any(c =>
                c.Nome.Equals(txtNome.Text.Trim(), StringComparison.OrdinalIgnoreCase));
            if (duplicado)
            {
                MessageBox.Show($"Já existe um cliente chamado '{txtNome.Text}'! 😅", "Duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Id=0 — o banco gera o Id real via AUTOINCREMENT
            _repo.Inserir(new Cliente(0, txtNome.Text.Trim(), txtContato.Text.Trim()));
            clientes = _repo.BuscarTodos();
            AtualizarLista();
            txtNome.Clear();
            txtContato.Clear();
            MessageBox.Show("Cliente cadastrado! ✅", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AtualizarLista()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientes.ToList();
        }
    }
}