namespace AtosCartorio.Views.Nascimento
{
    partial class ListaNascimento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise,</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvNascimentos = new DataGridView();
            panel1 = new Panel();
            btnExportar = new Button();
            btnExcluir = new Button();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvNascimentos).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvNascimentos
            // 
            dgvNascimentos.AllowUserToAddRows = false;
            dgvNascimentos.AllowUserToDeleteRows = false;
            dgvNascimentos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNascimentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNascimentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNascimentos.Location = new Point(22, 115);
            dgvNascimentos.Margin = new Padding(6);
            dgvNascimentos.MultiSelect = false;
            dgvNascimentos.Name = "dgvNascimentos";
            dgvNascimentos.ReadOnly = true;
            dgvNascimentos.RowHeadersWidth = 51;
            dgvNascimentos.RowTemplate.Height = 25;
            dgvNascimentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNascimentos.Size = new Size(1726, 808);
            dgvNascimentos.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(btnExportar);
            panel1.Controls.Add(btnExcluir);
            panel1.Location = new Point(22, 934);
            panel1.Margin = new Padding(6);
            panel1.Name = "panel1";
            panel1.Size = new Size(1726, 83);
            panel1.TabIndex = 1;
            // 
            // btnExportar
            // 
            btnExportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportar.Location = new Point(1350, 17);
            btnExportar.Margin = new Padding(6);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(176, 54);
            btnExportar.TabIndex = 1;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExcluir.Location = new Point(1545, 17);
            btnExcluir.Margin = new Padding(6);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(176, 54);
            btnExcluir.TabIndex = 0;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(22, 35);
            lblTitulo.Margin = new Padding(6, 0, 6, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(440, 57);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Lista de Nascimentos";
            // 
            // ListaNascimento
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1772, 1040);
            Controls.Add(lblTitulo);
            Controls.Add(panel1);
            Controls.Add(dgvNascimentos);
            Margin = new Padding(6);
            Name = "ListaNascimento";
            Text = "Listagem de Nascimentos";
            Load += ListaNascimento_Load;
            Shown += ListaNascimento_Shown;
            ((System.ComponentModel.ISupportInitialize)dgvNascimentos).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNascimentos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lblTitulo;
    }
}
