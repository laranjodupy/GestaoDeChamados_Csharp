namespace primeiroprograma_emCu.Forms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnAtendentes = new Button();
            btnClientes = new Button();
            btnChamados = new Button();
            SuspendLayout();
            // btnAtendentes
            btnAtendentes.Location = new Point(361, 292);
            btnAtendentes.Name = "btnAtendentes";
            btnAtendentes.Size = new Size(94, 29);
            btnAtendentes.TabIndex = 0;
            btnAtendentes.Text = "Atendentes";
            btnAtendentes.UseVisualStyleBackColor = true;
            btnAtendentes.Click += btnAtendentes_Click;
            // btnClientes
            btnClientes.Location = new Point(235, 292);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(94, 29);
            btnClientes.TabIndex = 1;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // btnChamados
            btnChamados.Location = new Point(497, 292);
            btnChamados.Name = "btnChamados";
            btnChamados.Size = new Size(94, 29);
            btnChamados.TabIndex = 2;
            btnChamados.Text = "Chamados";
            btnChamados.UseVisualStyleBackColor = true;
            btnChamados.Click += btnChamados_Click;
            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnChamados);
            Controls.Add(btnClientes);
            Controls.Add(btnAtendentes);
            Name = "Form1";
            Text = "Gestão de Chamados";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAtendentes;
        private Button btnClientes;
        private Button btnChamados;
    }
}