using System;
using System.Windows.Forms;

namespace AtosCartorio.Views.Obito
{
    partial class ListaObito
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed.</param>
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvObitos = new DataGridView();
            btnExcluir = new Button();
            btnExportar = new Button(); // Add Export button
            panel1 = new Panel();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvObitos).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvObitos
            // 
            dgvObitos.AllowUserToAddRows = false;
            dgvObitos.AllowUserToDeleteRows = false;
            dgvObitos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvObitos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvObitos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvObitos.Location = new Point(26, 122);
            dgvObitos.Margin = new Padding(6, 7, 6, 7);
            dgvObitos.MultiSelect = false;
            dgvObitos.Name = "dgvObitos";
            dgvObitos.ReadOnly = true;
            dgvObitos.RowHeadersVisible = false;
            dgvObitos.RowHeadersWidth = 92;
            dgvObitos.RowTemplate.Height = 25;
            dgvObitos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvObitos.Size = new Size(1401, 558);
            dgvObitos.TabIndex = 0;
            // 
            // btnExcluir
            // 
            btnExcluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExcluir.Location = new Point(1254, 17);
            btnExcluir.Margin = new Padding(6, 7, 6, 7);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(141, 53);
            btnExcluir.TabIndex = 2;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnExportar
            // 
            btnExportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportar.Location = new Point(1100, 17);
            btnExportar.Margin = new Padding(6, 7, 6, 7);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(141, 53);
            btnExportar.TabIndex = 3;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(btnExportar);
            panel1.Controls.Add(btnExcluir);
            panel1.Location = new Point(26, 694);
            panel1.Margin = new Padding(6, 7, 6, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(1401, 87);
            panel1.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(26, 37);
            lblTitulo.Margin = new Padding(6, 0, 6, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(318, 57);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Lista de Óbitos";
            // 
            // ListaObito
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1448, 797);
            Controls.Add(lblTitulo);
            Controls.Add(panel1);
            Controls.Add(dgvObitos);
            Margin = new Padding(6, 7, 6, 7);
            Name = "ListaObito";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listagem de Óbitos";
            Load += ListaObito_Load;
            Shown += ListaObito_Shown;
            ((System.ComponentModel.ISupportInitialize)dgvObitos).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvObitos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lblTitulo;
    }
}
