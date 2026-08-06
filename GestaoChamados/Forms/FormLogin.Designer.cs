namespace GestaoChamados.Forms
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtLogin = new TextBox();
            txtSenha = new TextBox();
            btnEntrar = new Button();
            SuspendLayout();

            // Título
            var lblTitulo = new Label()
            {
                Text = "🔐 Sistema de Chamados",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(100, 40)
            };

            var lblSub = new Label()
            {
                Text = "Faça login para continuar",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(180, 180, 180),
                AutoSize = true,
                Location = new Point(160, 85)
            };

            var lblLogin = new Label()
            {
                Text = "Usuário:",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(60, 140)
            };

            var lblSenha = new Label()
            {
                Text = "Senha:",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(60, 185)
            };

            // Campo de login
            txtLogin.Location = new Point(150, 137);
            txtLogin.Size = new Size(240, 27);
            txtLogin.Font = new Font("Segoe UI", 10F);
            txtLogin.BackColor = Color.FromArgb(50, 50, 65);
            txtLogin.ForeColor = Color.White;
            txtLogin.BorderStyle = BorderStyle.FixedSingle;

            // Campo de senha
            txtSenha.Location = new Point(150, 182);
            txtSenha.Size = new Size(240, 27);
            txtSenha.Font = new Font("Segoe UI", 10F);
            txtSenha.BackColor = Color.FromArgb(50, 50, 65);
            txtSenha.ForeColor = Color.White;
            txtSenha.BorderStyle = BorderStyle.FixedSingle;

            // Botão entrar
            btnEntrar.Location = new Point(150, 230);
            btnEntrar.Size = new Size(240, 42);
            btnEntrar.Text = "🚀 Entrar";
            btnEntrar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnEntrar.BackColor = Color.FromArgb(52, 152, 219);
            btnEntrar.ForeColor = Color.White;
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.FlatAppearance.BorderSize = 0;
            btnEntrar.Cursor = Cursors.Hand;
            btnEntrar.Click += btnEntrar_Click;

            // Dica de login padrão (remova antes de entregar se quiser)
            var lblDica = new Label()
            {
                Text = "Login padrão: admin / admin123",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(120, 120, 120),
                AutoSize = true,
                Location = new Point(155, 285)
            };

            // Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 330);
            BackColor = Color.FromArgb(30, 30, 40);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";

            Controls.Add(lblTitulo);
            Controls.Add(lblSub);
            Controls.Add(lblLogin);
            Controls.Add(lblSenha);
            Controls.Add(txtLogin);
            Controls.Add(txtSenha);
            Controls.Add(btnEntrar);
            Controls.Add(lblDica);

            ResumeLayout(false);
        }

        private TextBox txtLogin;
        private TextBox txtSenha;
        private Button btnEntrar;
    }
}
