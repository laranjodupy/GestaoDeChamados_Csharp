namespace primeiroprograma_emCu.Forms
{
    partial class FormChamado
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
            txtDescricao = new TextBox();
            btnAbrir = new Button();
            btnAlterarStatus = new Button();
            cmbClientes = new ComboBox();
            cmbAtendentes = new ComboBox();
            cmbStatus = new ComboBox();
            dgvChamados = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvChamados).BeginInit();
            SuspendLayout();

            var lblTitulo = new Label() { Text = "📋 Gestão de Chamados", Font = new Font("Segoe UI", 14F, FontStyle.Bold), ForeColor = Color.White, AutoSize = true, Location = new Point(20, 20) };
            var lblCliente = new Label() { Text = "Cliente:", Font = new Font("Segoe UI", 10F), ForeColor = Color.White, AutoSize = true, Location = new Point(20, 75) };
            var lblAtendente = new Label() { Text = "Atendente:", Font = new Font("Segoe UI", 10F), ForeColor = Color.White, AutoSize = true, Location = new Point(20, 115) };
            var lblDescricao = new Label() { Text = "Descrição:", Font = new Font("Segoe UI", 10F), ForeColor = Color.White, AutoSize = true, Location = new Point(20, 155) };
            var lblStatus = new Label() { Text = "Novo Status:", Font = new Font("Segoe UI", 10F), ForeColor = Color.White, AutoSize = true, Location = new Point(430, 75) };

            cmbClientes.Location = new Point(120, 72);
            cmbClientes.Size = new Size(230, 27);
            cmbClientes.Font = new Font("Segoe UI", 10F);
            cmbClientes.BackColor = Color.FromArgb(50, 50, 65);
            cmbClientes.ForeColor = Color.White;
            cmbClientes.FlatStyle = FlatStyle.Flat;
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbAtendentes.Location = new Point(120, 112);
            cmbAtendentes.Size = new Size(230, 27);
            cmbAtendentes.Font = new Font("Segoe UI", 10F);
            cmbAtendentes.BackColor = Color.FromArgb(50, 50, 65);
            cmbAtendentes.ForeColor = Color.White;
            cmbAtendentes.FlatStyle = FlatStyle.Flat;
            cmbAtendentes.DropDownStyle = ComboBoxStyle.DropDownList;

            txtDescricao.Location = new Point(120, 152);
            txtDescricao.Size = new Size(230, 27);
            txtDescricao.Font = new Font("Segoe UI", 10F);
            txtDescricao.BackColor = Color.FromArgb(50, 50, 65);
            txtDescricao.ForeColor = Color.White;
            txtDescricao.BorderStyle = BorderStyle.FixedSingle;

            cmbStatus.Location = new Point(550, 72);
            cmbStatus.Size = new Size(160, 27);
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.BackColor = Color.FromArgb(50, 50, 65);
            cmbStatus.ForeColor = Color.White;
            cmbStatus.FlatStyle = FlatStyle.Flat;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new string[] { "Em Andamento", "Resolvido" });
            cmbStatus.SelectedIndex = 0;

            btnAbrir.Location = new Point(120, 195);
            btnAbrir.Size = new Size(150, 38);
            btnAbrir.Text = "✔ Abrir Chamado";
            btnAbrir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAbrir.BackColor = Color.FromArgb(52, 152, 219);
            btnAbrir.ForeColor = Color.White;
            btnAbrir.FlatStyle = FlatStyle.Flat;
            btnAbrir.FlatAppearance.BorderSize = 0;
            btnAbrir.Cursor = Cursors.Hand;
            btnAbrir.Click += btnAbrir_Click;

            btnAlterarStatus.Location = new Point(550, 112);
            btnAlterarStatus.Size = new Size(160, 38);
            btnAlterarStatus.Text = "🔄 Alterar Status";
            btnAlterarStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAlterarStatus.BackColor = Color.FromArgb(231, 76, 60);
            btnAlterarStatus.ForeColor = Color.White;
            btnAlterarStatus.FlatStyle = FlatStyle.Flat;
            btnAlterarStatus.FlatAppearance.BorderSize = 0;
            btnAlterarStatus.Cursor = Cursors.Hand;
            btnAlterarStatus.Click += btnAlterarStatus_Click;

            dgvChamados.Location = new Point(20, 250);
            dgvChamados.Size = new Size(755, 170);
            dgvChamados.ReadOnly = true;
            dgvChamados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChamados.BackgroundColor = Color.FromArgb(40, 40, 55);
            dgvChamados.GridColor = Color.FromArgb(60, 60, 80);
            dgvChamados.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 55);
            dgvChamados.DefaultCellStyle.ForeColor = Color.White;
            dgvChamados.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvChamados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(231, 76, 60);
            dgvChamados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvChamados.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvChamados.EnableHeadersVisualStyles = false;
            dgvChamados.BorderStyle = BorderStyle.None;
            dgvChamados.RowHeadersVisible = false;
            dgvChamados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ((System.ComponentModel.ISupportInitialize)dgvChamados).EndInit();

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            BackColor = Color.FromArgb(30, 30, 40);
            Controls.Add(lblTitulo);
            Controls.Add(lblCliente);
            Controls.Add(lblAtendente);
            Controls.Add(lblDescricao);
            Controls.Add(lblStatus);
            Controls.Add(cmbClientes);
            Controls.Add(cmbAtendentes);
            Controls.Add(txtDescricao);
            Controls.Add(cmbStatus);
            Controls.Add(btnAbrir);
            Controls.Add(btnAlterarStatus);
            Controls.Add(dgvChamados);
            Text = "Chamados";
            ResumeLayout(false);
        }

        private TextBox txtDescricao;
        private Button btnAbrir;
        private Button btnAlterarStatus;
        private ComboBox cmbClientes;
        private ComboBox cmbAtendentes;
        private ComboBox cmbStatus;
        private DataGridView dgvChamados;
    }
}