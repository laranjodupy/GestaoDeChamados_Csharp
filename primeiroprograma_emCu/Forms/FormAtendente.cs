using primeiroprograma_emCu.Models;

namespace primeiroprograma_emCu.Forms
{
    public partial class FormAtendente : Form
    {
        private List<Atendente> atendentes;
        private int proximoId = 1;

        public FormAtendente(List<Atendente> atendentes)
        {
            InitializeComponent();
            this.atendentes = atendentes;
            AtualizarLista();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtSetor.Text))
            {
                MessageBox.Show("Preenche nome e setor!");
                return;
            }

            Atendente novo = new Atendente(proximoId++, txtNome.Text, txtSetor.Text);
            atendentes.Add(novo);
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
