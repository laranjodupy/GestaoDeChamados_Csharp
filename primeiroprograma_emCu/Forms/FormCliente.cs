using primeiroprograma_emCu.Models;
using primeiroprograma_emCu.Services;

namespace primeiroprograma_emCu.Forms
{
    public partial class FormCliente : Form
    {
        private List<Cliente> clientes;
        private int proximoId = 1;

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
                MessageBox.Show("Preenche nome e contato meu rei! 👑", "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica duplicata — ignora maiúsculas/minúsculas
            bool duplicado = clientes.Any(c => c.Nome.Equals(txtNome.Text.Trim(), StringComparison.OrdinalIgnoreCase));
            if (duplicado)
            {
                MessageBox.Show($"Eita! Já existe um cliente chamado '{txtNome.Text}' no sistema! 😅", "Cliente duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente novo = new Cliente(proximoId++, txtNome.Text.Trim(), txtContato.Text.Trim());
            clientes.Add(novo);
            AtualizarLista();
            txtNome.Clear();
            txtContato.Clear();
            MessageBox.Show("Cliente cadastrado com sucesso! ✅", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AtualizarLista()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientes.ToList();
        }
    }
}