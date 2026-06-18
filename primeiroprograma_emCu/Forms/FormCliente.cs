using primeiroprograma_emCu.Models;
using primeiroprograma_emCu.Services;
using primeiroprograma_emCu.Repositories;

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
            bool podeCadastrar =
                PermissionService.TemPermissao(
                    Sessao.UsuarioAtual.Papel,
                    Permissao.CadastrarCliente);

            btnCadastrar.Enabled = podeCadastrar;
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!PermissionService.TemPermissao(
                Sessao.UsuarioAtual.Papel,
                Permissao.CadastrarCliente))
            {
                MessageBox.Show("Acesso negado.");
                return;
            }
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