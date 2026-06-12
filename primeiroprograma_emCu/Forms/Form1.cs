using primeiroprograma_emCu.Models;

namespace primeiroprograma_emCu.Forms
{
    public partial class Form1 : Form
    {
        private List<Cliente> clientes = new List<Cliente>();
        private List<Atendente> atendentes = new List<Atendente>();
        private List<Chamado> chamados = new List<Chamado>();

        public Form1()
        {
            InitializeComponent();

            // Dados mockados pra teste
            clientes.Add(new Cliente(1, "Guigui do job", "quatrozerozerodois"));
            clientes.Add(new Cliente(2, "Maria Souza", "oitonovedoisdois"));
            atendentes.Add(new Atendente(1, "Vitin deviops", "Menino do pc"));
            atendentes.Add(new Atendente(2, "Ana do PCC", "Tráfico"));

            AtualizarContador();
        }

        // Atualiza o contador toda vez que um formulário fecha
        private void AtualizarContador()
        {
            int abertos = chamados.Count(c => c.Status == "Aberto");
            int emAndamento = chamados.Count(c => c.Status == "Em Andamento");
            lblContador.Text = $"tem {abertos} baguios abertos   & {emAndamento} mizeras em andamento";
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            new FormCliente(clientes).ShowDialog();
            AtualizarContador();
        }

        private void btnAtendentes_Click(object sender, EventArgs e)
        {
            new FormAtendente(atendentes).ShowDialog();
            AtualizarContador();
        }

        private void btnChamados_Click(object sender, EventArgs e)
        {
            new FormChamado(chamados, clientes, atendentes).ShowDialog();
            AtualizarContador();
        }
    }
}