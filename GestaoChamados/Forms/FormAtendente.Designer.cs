namespace GestaoChamados.Forms
{
    partial class FormAtendente
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
            txtNome = new TextBox();
            txtSetor = new TextBox();
            btnCadastrar = new Button();
            dgvAtendentes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAtendentes).BeginInit();
            SuspendLayout();

            var lblTitulo = new Label() { Text = "🧑‍💼 Cadastro de Atendentes", Font = new Font("Segoe UI", 14F, FontStyle.Bold), ForeColor = Color.White, AutoSize = true, Location = new Point(20, 20) };
            var lblNome = new Label() { Text = "Nome:", Font = new Font("Segoe UI", 10F), ForeColor = Color.White, AutoSize = true, Location = new Point(20, 75) };
            var lblSetor = new Label() { Text = "Setor:", Font = new Font("Segoe UI", 10F), ForeColor = Color.White, AutoSize = true, Location = new Point(20, 115) };

            txtNome.Location = new Point(120, 72);
            txtNome.Size = new Size(250, 27);
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.BackColor = Color.FromArgb(50, 50, 65);
            txtNome.ForeColor = Color.White;
            txtNome.BorderStyle = BorderStyle.FixedSingle;

            txtSetor.Location = new Point(120, 112);
            txtSetor.Size = new Size(250, 27);
            txtSetor.Font = new Font("Segoe UI", 10F);
            txtSetor.BackColor = Color.FromArgb(50, 50, 65);
            txtSetor.ForeColor = Color.White;
            txtSetor.BorderStyle = BorderStyle.FixedSingle;

            btnCadastrar.Location = new Point(120, 155);
            btnCadastrar.Size = new Size(140, 38);
            btnCadastrar.Text = "✔ Cadastrar";
            btnCadastrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCadastrar.BackColor = Color.FromArgb(46, 204, 113);
            btnCadastrar.ForeColor = Color.White;
            btnCadastrar.FlatStyle = FlatStyle.Flat;
            btnCadastrar.FlatAppearance.BorderSize = 0;
            btnCadastrar.Cursor = Cursors.Hand;
            btnCadastrar.Click += btnCadastrar_Click;

            dgvAtendentes.Location = new Point(20, 210);
            dgvAtendentes.Size = new Size(755, 210);
            dgvAtendentes.ReadOnly = true;
            dgvAtendentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAtendentes.BackgroundColor = Color.FromArgb(40, 40, 55);
            dgvAtendentes.GridColor = Color.FromArgb(60, 60, 80);
            dgvAtendentes.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 55);
            dgvAtendentes.DefaultCellStyle.ForeColor = Color.White;
            dgvAtendentes.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvAtendentes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 204, 113);
            dgvAtendentes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAtendentes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvAtendentes.EnableHeadersVisualStyles = false;
            dgvAtendentes.BorderStyle = BorderStyle.None;
            dgvAtendentes.RowHeadersVisible = false;
            dgvAtendentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ((System.ComponentModel.ISupportInitialize)dgvAtendentes).EndInit();

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            BackColor = Color.FromArgb(30, 30, 40);
            Controls.Add(lblTitulo);
            Controls.Add(lblNome);
            Controls.Add(lblSetor);
            Controls.Add(txtNome);
            Controls.Add(txtSetor);
            Controls.Add(btnCadastrar);
            Controls.Add(dgvAtendentes);
            Text = "Atendentes";
            ResumeLayout(false);
        }

        private TextBox txtNome;
        private TextBox txtSetor;
        private Button btnCadastrar;
        private DataGridView dgvAtendentes;
    }
}