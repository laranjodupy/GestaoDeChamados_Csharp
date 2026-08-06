namespace GestaoChamados.Forms
{
    partial class FormCliente
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
            txtContato = new TextBox();
            btnCadastrar = new Button();
            dgvClientes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();

            var lblTitulo = new Label() { Text = "👤 Cadastro de Clientes", Font = new Font("Segoe UI", 14F, FontStyle.Bold), ForeColor = Color.White, AutoSize = true, Location = new Point(20, 20) };
            var lblNome = new Label() { Text = "Nome:", Font = new Font("Segoe UI", 10F), ForeColor = Color.White, AutoSize = true, Location = new Point(20, 75) };
            var lblContato = new Label() { Text = "Contato:", Font = new Font("Segoe UI", 10F), ForeColor = Color.White, AutoSize = true, Location = new Point(20, 115) };

            txtNome.Location = new Point(120, 72);
            txtNome.Size = new Size(250, 27);
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.BackColor = Color.FromArgb(50, 50, 65);
            txtNome.ForeColor = Color.White;
            txtNome.BorderStyle = BorderStyle.FixedSingle;

            txtContato.Location = new Point(120, 112);
            txtContato.Size = new Size(250, 27);
            txtContato.Font = new Font("Segoe UI", 10F);
            txtContato.BackColor = Color.FromArgb(50, 50, 65);
            txtContato.ForeColor = Color.White;
            txtContato.BorderStyle = BorderStyle.FixedSingle;

            btnCadastrar.Location = new Point(120, 155);
            btnCadastrar.Size = new Size(140, 38);
            btnCadastrar.Text = "✔ Cadastrar";
            btnCadastrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCadastrar.BackColor = Color.FromArgb(52, 152, 219);
            btnCadastrar.ForeColor = Color.White;
            btnCadastrar.FlatStyle = FlatStyle.Flat;
            btnCadastrar.FlatAppearance.BorderSize = 0;
            btnCadastrar.Cursor = Cursors.Hand;
            btnCadastrar.Click += btnCadastrar_Click;

            dgvClientes.Location = new Point(20, 210);
            dgvClientes.Size = new Size(755, 210);
            dgvClientes.ReadOnly = true;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = Color.FromArgb(40, 40, 55);
            dgvClientes.GridColor = Color.FromArgb(60, 60, 80);
            dgvClientes.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 55);
            dgvClientes.DefaultCellStyle.ForeColor = Color.White;
            dgvClientes.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            BackColor = Color.FromArgb(30, 30, 40);
            Controls.Add(lblTitulo);
            Controls.Add(lblNome);
            Controls.Add(lblContato);
            Controls.Add(txtNome);
            Controls.Add(txtContato);
            Controls.Add(btnCadastrar);
            Controls.Add(dgvClientes);
            Text = "Clientes";
            ResumeLayout(false);
        }

        private TextBox txtNome;
        private TextBox txtContato;
        private Button btnCadastrar;
        private DataGridView dgvClientes;
    }
}