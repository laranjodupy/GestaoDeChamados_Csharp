using GestaoChamados.Services;

namespace GestaoChamados.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            // Esconde os caracteres da senha
            txtSenha.PasswordChar = '*';
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Preenche login e senha!", "Campos vazios",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sucesso = AuthService.Login(txtLogin.Text.Trim(), txtSenha.Text);

            if (sucesso)
            {
                // DialogResult.OK sinaliza pro Program.cs que o login funcionou
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Login ou senha incorretos!", "Acesso negado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Clear();
                txtLogin.Focus();
            }
        }
    }
}