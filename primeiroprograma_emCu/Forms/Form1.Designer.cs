namespace primeiroprograma_emCu.Forms
{
    partial class Form1
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
            btnClientes = new Button();
            btnAtendentes = new Button();
            btnChamados = new Button();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            SuspendLayout();
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.FromArgb(52, 152, 219);
            btnClientes.Cursor = Cursors.Hand;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClientes.ForeColor = Color.White;
            btnClientes.Location = new Point(100, 230);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(180, 55);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "👤  Fis dus canso";
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnAtendentes
            // 
            btnAtendentes.BackColor = Color.FromArgb(46, 204, 113);
            btnAtendentes.Cursor = Cursors.Hand;
            btnAtendentes.FlatAppearance.BorderSize = 0;
            btnAtendentes.FlatStyle = FlatStyle.Flat;
            btnAtendentes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAtendentes.ForeColor = Color.White;
            btnAtendentes.Location = new Point(310, 230);
            btnAtendentes.Name = "btnAtendentes";
            btnAtendentes.Size = new Size(180, 55);
            btnAtendentes.TabIndex = 3;
            btnAtendentes.Text = "\U0001f9d1‍💼  Atendentes";
            btnAtendentes.UseVisualStyleBackColor = false;
            btnAtendentes.Click += btnAtendentes_Click;
            // 
            // btnChamados
            // 
            btnChamados.BackColor = Color.FromArgb(231, 76, 60);
            btnChamados.Cursor = Cursors.Hand;
            btnChamados.FlatAppearance.BorderSize = 0;
            btnChamados.FlatStyle = FlatStyle.Flat;
            btnChamados.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnChamados.ForeColor = Color.White;
            btnChamados.Location = new Point(520, 230);
            btnChamados.Name = "btnChamados";
            btnChamados.Size = new Size(180, 55);
            btnChamados.TabIndex = 4;
            btnChamados.Text = "📋  Chatices";
            btnChamados.UseVisualStyleBackColor = false;
            btnChamados.Click += btnChamados_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(200, 80);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(447, 50);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "🎫 Gestão de Chatices";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 11F);
            lblSubtitulo.ForeColor = Color.FromArgb(180, 180, 180);
            lblSubtitulo.Location = new Point(315, 130);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(242, 25);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Sistema do DesSuporte ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 40);
            ClientSize = new Size(1069, 450);
            Controls.Add(lblTitulo);
            Controls.Add(lblSubtitulo);
            Controls.Add(btnClientes);
            Controls.Add(btnAtendentes);
            Controls.Add(btnChamados);
            Name = "Form1";
            Text = "Gestão de Chatices";
            lblContador = new Label();
            lblContador.Text = "📋 0 aberto(s)   🔄 0 em andamento";
            lblContador.Font = new Font("Segoe UI", 10F);
            lblContador.ForeColor = Color.FromArgb(180, 180, 180);
            lblContador.AutoSize = true;
            lblContador.Location = new Point(270, 170);
            Controls.Add(lblContador);
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnClientes;
        private Button btnAtendentes;
        private Button btnChamados;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblContador;
    }
}