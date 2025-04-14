namespace AtosCartorio.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise.</param>
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
            menuStripMain = new MenuStrip();
            arquivoToolStripMenuItem = new ToolStripMenuItem();
            sairToolStripMenuItem = new ToolStripMenuItem();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            casamentosToolStripMenuItem = new ToolStripMenuItem();
            novoCasamentoToolStripMenuItem = new ToolStripMenuItem();
            listagemCasamentosToolStripMenuItem = new ToolStripMenuItem();
            obitosToolStripMenuItem = new ToolStripMenuItem();
            novoObitoToolStripMenuItem = new ToolStripMenuItem();
            listagemObitosToolStripMenuItem = new ToolStripMenuItem();
            nascimentosToolStripMenuItem = new ToolStripMenuItem();
            novoNascimentoToolStripMenuItem = new ToolStripMenuItem();
            listagemNascimentosToolStripMenuItem = new ToolStripMenuItem();
            ferramentasToolStripMenuItem = new ToolStripMenuItem();
            atualizarBancoDeDadosToolStripMenuItem = new ToolStripMenuItem();
            recriarBancoDeDadosToolStripMenuItem = new ToolStripMenuItem();
            ajudaToolStripMenuItem = new ToolStripMenuItem();
            sobreToolStripMenuItem = new ToolStripMenuItem();
            statusStripMain = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            panelMain = new Panel();
            menuStripMain.SuspendLayout();
            statusStripMain.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripMain
            // 
            menuStripMain.ImageScalingSize = new Size(36, 36);
            menuStripMain.Items.AddRange(new ToolStripItem[] { arquivoToolStripMenuItem, cadastrosToolStripMenuItem, ferramentasToolStripMenuItem, ajudaToolStripMenuItem });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Padding = new Padding(13, 5, 0, 5);
            menuStripMain.Size = new Size(1714, 53);
            menuStripMain.TabIndex = 0;
            menuStripMain.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            arquivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sairToolStripMenuItem });
            arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            arquivoToolStripMenuItem.Size = new Size(132, 43);
            arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            sairToolStripMenuItem.Size = new Size(211, 48);
            sairToolStripMenuItem.Text = "Sair";
            sairToolStripMenuItem.Click += sairToolStripMenuItem_Click;
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { casamentosToolStripMenuItem, obitosToolStripMenuItem, nascimentosToolStripMenuItem });
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(156, 43);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // casamentosToolStripMenuItem
            // 
            casamentosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novoCasamentoToolStripMenuItem, listagemCasamentosToolStripMenuItem });
            casamentosToolStripMenuItem.Name = "casamentosToolStripMenuItem";
            casamentosToolStripMenuItem.Size = new Size(319, 48);
            casamentosToolStripMenuItem.Text = "Casamentos";
            // 
            // novoCasamentoToolStripMenuItem
            // 
            novoCasamentoToolStripMenuItem.Name = "novoCasamentoToolStripMenuItem";
            novoCasamentoToolStripMenuItem.Size = new Size(274, 48);
            novoCasamentoToolStripMenuItem.Text = "Novo";
            novoCasamentoToolStripMenuItem.Click += novoCasamentoToolStripMenuItem_Click;
            // 
            // listagemCasamentosToolStripMenuItem
            // 
            listagemCasamentosToolStripMenuItem.Name = "listagemCasamentosToolStripMenuItem";
            listagemCasamentosToolStripMenuItem.Size = new Size(274, 48);
            listagemCasamentosToolStripMenuItem.Text = "Listagem";
            listagemCasamentosToolStripMenuItem.Click += listagemCasamentosToolStripMenuItem_Click;
            // 
            // obitosToolStripMenuItem
            // 
            obitosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novoObitoToolStripMenuItem, listagemObitosToolStripMenuItem });
            obitosToolStripMenuItem.Name = "obitosToolStripMenuItem";
            obitosToolStripMenuItem.Size = new Size(319, 48);
            obitosToolStripMenuItem.Text = "Óbitos";
            // 
            // novoObitoToolStripMenuItem
            // 
            novoObitoToolStripMenuItem.Name = "novoObitoToolStripMenuItem";
            novoObitoToolStripMenuItem.Size = new Size(274, 48);
            novoObitoToolStripMenuItem.Text = "Novo";
            novoObitoToolStripMenuItem.Click += novoObitoToolStripMenuItem_Click;
            // 
            // listagemObitosToolStripMenuItem
            // 
            listagemObitosToolStripMenuItem.Name = "listagemObitosToolStripMenuItem";
            listagemObitosToolStripMenuItem.Size = new Size(274, 48);
            listagemObitosToolStripMenuItem.Text = "Listagem";
            listagemObitosToolStripMenuItem.Click += listagemObitosToolStripMenuItem_Click;
            // 
            // nascimentosToolStripMenuItem
            // 
            nascimentosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novoNascimentoToolStripMenuItem, listagemNascimentosToolStripMenuItem });
            nascimentosToolStripMenuItem.Name = "nascimentosToolStripMenuItem";
            nascimentosToolStripMenuItem.Size = new Size(319, 48);
            nascimentosToolStripMenuItem.Text = "Nascimentos";
            // 
            // novoNascimentoToolStripMenuItem
            // 
            novoNascimentoToolStripMenuItem.Name = "novoNascimentoToolStripMenuItem";
            novoNascimentoToolStripMenuItem.Size = new Size(274, 48);
            novoNascimentoToolStripMenuItem.Text = "Novo";
            novoNascimentoToolStripMenuItem.Click += novoNascimentoToolStripMenuItem_Click;
            // 
            // listagemNascimentosToolStripMenuItem
            // 
            listagemNascimentosToolStripMenuItem.Name = "listagemNascimentosToolStripMenuItem";
            listagemNascimentosToolStripMenuItem.Size = new Size(274, 48);
            listagemNascimentosToolStripMenuItem.Text = "Listagem";
            listagemNascimentosToolStripMenuItem.Click += listagemNascimentosToolStripMenuItem_Click;
            // 
            // ferramentasToolStripMenuItem
            // 
            ferramentasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { atualizarBancoDeDadosToolStripMenuItem, recriarBancoDeDadosToolStripMenuItem });
            ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            ferramentasToolStripMenuItem.Size = new Size(184, 43);
            ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // atualizarBancoDeDadosToolStripMenuItem
            // 
            atualizarBancoDeDadosToolStripMenuItem.Name = "atualizarBancoDeDadosToolStripMenuItem";
            atualizarBancoDeDadosToolStripMenuItem.Size = new Size(470, 48);
            atualizarBancoDeDadosToolStripMenuItem.Text = "Atualizar Banco de Dados";
            atualizarBancoDeDadosToolStripMenuItem.Click += atualizarBancoDeDadosToolStripMenuItem_Click;
            // 
            // recriarBancoDeDadosToolStripMenuItem
            // 
            recriarBancoDeDadosToolStripMenuItem.Name = "recriarBancoDeDadosToolStripMenuItem";
            recriarBancoDeDadosToolStripMenuItem.Size = new Size(470, 48);
            recriarBancoDeDadosToolStripMenuItem.Text = "Recriar Banco de Dados";
            recriarBancoDeDadosToolStripMenuItem.Click += recriarBancoDeDadosToolStripMenuItem_Click;
            // 
            // ajudaToolStripMenuItem
            // 
            ajudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sobreToolStripMenuItem });
            ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            ajudaToolStripMenuItem.Size = new Size(108, 43);
            ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // sobreToolStripMenuItem
            // 
            sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            sobreToolStripMenuItem.Size = new Size(403, 48);
            sobreToolStripMenuItem.Text = "Sobre";
            // 
            // statusStripMain
            // 
            statusStripMain.ImageScalingSize = new Size(36, 36);
            statusStripMain.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStripMain.Location = new Point(0, 1062);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.Padding = new Padding(2, 0, 30, 0);
            statusStripMain.Size = new Size(1714, 48);
            statusStripMain.TabIndex = 1;
            statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(213, 37);
            toolStripStatusLabel.Text = "Sistema Cartório";
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 53);
            panelMain.Margin = new Padding(6, 7, 6, 7);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1714, 1009);
            panelMain.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1714, 1110);
            Controls.Add(panelMain);
            Controls.Add(statusStripMain);
            Controls.Add(menuStripMain);
            MainMenuStrip = menuStripMain;
            Margin = new Padding(6, 7, 6, 7);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Cartório";
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            statusStripMain.ResumeLayout(false);
            statusStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStripMenuItem casamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoCasamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listagemCasamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obitosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoObitoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listagemObitosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nascimentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoNascimentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listagemNascimentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atualizarBancoDeDadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recriarBancoDeDadosToolStripMenuItem;
    }
}