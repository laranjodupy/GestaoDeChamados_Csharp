namespace primeiroprograma_emCu
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAtendentes = new Button();
            label1 = new Label();
            btnClientes = new Button();
            btnChamados = new Button();
            SuspendLayout();
            // 
            // btnAtendentes
            // 
            btnAtendentes.Location = new Point(361, 292);
            btnAtendentes.Name = "btnAtendentes";
            btnAtendentes.Size = new Size(94, 29);
            btnAtendentes.TabIndex = 0;
            btnAtendentes.Text = "Atendentes";
            btnAtendentes.UseVisualStyleBackColor = true;
            btnAtendentes.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(361, 169);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // btnClientes
            // 
            btnClientes.Location = new Point(235, 292);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(94, 29);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            // 
            // btnChamados
            // 
            btnChamados.Location = new Point(497, 292);
            btnChamados.Name = "btnChamados";
            btnChamados.Size = new Size(94, 29);
            btnChamados.TabIndex = 3;
            btnChamados.Text = "Chamados";
            btnChamados.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnChamados);
            Controls.Add(btnClientes);
            Controls.Add(label1);
            Controls.Add(btnAtendentes);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAtendentes;
        private Label label1;
        private Button btnClientes;
        private Button btnChamados;
    }
}
