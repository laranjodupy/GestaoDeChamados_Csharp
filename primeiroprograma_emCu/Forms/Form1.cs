using primeiroprograma_emCu.Forms;

namespace primeiroprograma_emCu.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormCliente formCliente = new FormCliente();
            formCliente.ShowDialog();
        }

        private void btnAtendentes_Click(object sender, EventArgs e)
        {
            FormAtendente formAtendente = new FormAtendente();
            formAtendente.ShowDialog();
        }

        private void btnChamados_Click(object sender, EventArgs e)
        {
            FormChamado formChamado = new FormChamado();
            formChamado.ShowDialog();
        }
    }
}