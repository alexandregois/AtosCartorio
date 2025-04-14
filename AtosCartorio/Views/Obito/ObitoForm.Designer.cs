namespace AtosCartorio.Views
{
    partial class ObitoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSalvar = new Button();
            dtpDataRegistro = new DateTimePicker();
            dtpDataObito = new DateTimePicker();
            txtNomeFalecido = new TextBox();
            dtpDataNascimento = new DateTimePicker();
            txtNomePai = new TextBox();
            txtNomeMae = new TextBox();
            dtpDataNascimentoPai = new DateTimePicker();
            dtpDataNascimentoMae = new DateTimePicker();
            lblDataRegistro = new Label();
            lblDataObito = new Label();
            lblNomeFalecido = new Label();
            lblDataNascimento = new Label();
            lblNomePai = new Label();
            lblNomeMae = new Label();
            lblDataNascimentoPai = new Label();
            lblDataNascimentoMae = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(414, 246);
            btnSalvar.Margin = new Padding(2, 2, 2, 2);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(92, 29);
            btnSalvar.TabIndex = 17;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // dtpDataRegistro
            // 
            dtpDataRegistro.Format = DateTimePickerFormat.Short;
            dtpDataRegistro.Location = new Point(168, 18);
            dtpDataRegistro.Margin = new Padding(2, 2, 2, 2);
            dtpDataRegistro.Name = "dtpDataRegistro";
            dtpDataRegistro.Size = new Size(125, 27);
            dtpDataRegistro.TabIndex = 2;
            // 
            // dtpDataObito
            // 
            dtpDataObito.Format = DateTimePickerFormat.Short;
            dtpDataObito.Location = new Point(168, 50);
            dtpDataObito.Margin = new Padding(2, 2, 2, 2);
            dtpDataObito.Name = "dtpDataObito";
            dtpDataObito.Size = new Size(125, 27);
            dtpDataObito.TabIndex = 4;
            // 
            // txtNomeFalecido
            // 
            txtNomeFalecido.Location = new Point(168, 81);
            txtNomeFalecido.Margin = new Padding(2, 2, 2, 2);
            txtNomeFalecido.Name = "txtNomeFalecido";
            txtNomeFalecido.Size = new Size(340, 27);
            txtNomeFalecido.TabIndex = 6;
            // 
            // dtpDataNascimento
            // 
            dtpDataNascimento.Format = DateTimePickerFormat.Short;
            dtpDataNascimento.Location = new Point(168, 112);
            dtpDataNascimento.Margin = new Padding(2, 2, 2, 2);
            dtpDataNascimento.Name = "dtpDataNascimento";
            dtpDataNascimento.Size = new Size(125, 27);
            dtpDataNascimento.TabIndex = 8;
            // 
            // txtNomePai
            // 
            txtNomePai.Location = new Point(168, 143);
            txtNomePai.Margin = new Padding(2, 2, 2, 2);
            txtNomePai.Name = "txtNomePai";
            txtNomePai.Size = new Size(340, 27);
            txtNomePai.TabIndex = 10;
            // 
            // txtNomeMae
            // 
            txtNomeMae.Location = new Point(168, 175);
            txtNomeMae.Margin = new Padding(2, 2, 2, 2);
            txtNomeMae.Name = "txtNomeMae";
            txtNomeMae.Size = new Size(340, 27);
            txtNomeMae.TabIndex = 12;
            // 
            // dtpDataNascimentoPai
            // 
            dtpDataNascimentoPai.Format = DateTimePickerFormat.Short;
            dtpDataNascimentoPai.Location = new Point(168, 206);
            dtpDataNascimentoPai.Margin = new Padding(2, 2, 2, 2);
            dtpDataNascimentoPai.Name = "dtpDataNascimentoPai";
            dtpDataNascimentoPai.ShowCheckBox = true;
            dtpDataNascimentoPai.Size = new Size(125, 27);
            dtpDataNascimentoPai.TabIndex = 14;
            // 
            // dtpDataNascimentoMae
            // 
            dtpDataNascimentoMae.Format = DateTimePickerFormat.Short;
            dtpDataNascimentoMae.Location = new Point(383, 206);
            dtpDataNascimentoMae.Margin = new Padding(2, 2, 2, 2);
            dtpDataNascimentoMae.Name = "dtpDataNascimentoMae";
            dtpDataNascimentoMae.ShowCheckBox = true;
            dtpDataNascimentoMae.Size = new Size(125, 27);
            dtpDataNascimentoMae.TabIndex = 16;
            // 
            // lblDataRegistro
            // 
            lblDataRegistro.AutoSize = true;
            lblDataRegistro.Location = new Point(19, 19);
            lblDataRegistro.Margin = new Padding(2, 0, 2, 0);
            lblDataRegistro.Name = "lblDataRegistro";
            lblDataRegistro.Size = new Size(124, 20);
            lblDataRegistro.TabIndex = 1;
            lblDataRegistro.Text = "Data de Registro:";
            // 
            // lblDataObito
            // 
            lblDataObito.AutoSize = true;
            lblDataObito.Location = new Point(19, 50);
            lblDataObito.Margin = new Padding(2, 0, 2, 0);
            lblDataObito.Name = "lblDataObito";
            lblDataObito.Size = new Size(107, 20);
            lblDataObito.TabIndex = 3;
            lblDataObito.Text = "Data de Óbito:";
            // 
            // lblNomeFalecido
            // 
            lblNomeFalecido.AutoSize = true;
            lblNomeFalecido.Location = new Point(19, 81);
            lblNomeFalecido.Margin = new Padding(2, 0, 2, 0);
            lblNomeFalecido.Name = "lblNomeFalecido";
            lblNomeFalecido.Size = new Size(134, 20);
            lblNomeFalecido.TabIndex = 5;
            lblNomeFalecido.Text = "Nome do Falecido:";
            // 
            // lblDataNascimento
            // 
            lblDataNascimento.AutoSize = true;
            lblDataNascimento.Location = new Point(19, 112);
            lblDataNascimento.Margin = new Padding(2, 0, 2, 0);
            lblDataNascimento.Name = "lblDataNascimento";
            lblDataNascimento.Size = new Size(148, 20);
            lblDataNascimento.TabIndex = 7;
            lblDataNascimento.Text = "Data de Nascimento:";
            // 
            // lblNomePai
            // 
            lblNomePai.AutoSize = true;
            lblNomePai.Location = new Point(19, 144);
            lblNomePai.Margin = new Padding(2, 0, 2, 0);
            lblNomePai.Name = "lblNomePai";
            lblNomePai.Size = new Size(98, 20);
            lblNomePai.TabIndex = 9;
            lblNomePai.Text = "Nome do Pai:";
            // 
            // lblNomeMae
            // 
            lblNomeMae.AutoSize = true;
            lblNomeMae.Location = new Point(19, 175);
            lblNomeMae.Margin = new Padding(2, 0, 2, 0);
            lblNomeMae.Name = "lblNomeMae";
            lblNomeMae.Size = new Size(107, 20);
            lblNomeMae.TabIndex = 11;
            lblNomeMae.Text = "Nome da Mãe:";
            // 
            // lblDataNascimentoPai
            // 
            lblDataNascimentoPai.AutoSize = true;
            lblDataNascimentoPai.Location = new Point(19, 206);
            lblDataNascimentoPai.Margin = new Padding(2, 0, 2, 0);
            lblDataNascimentoPai.Name = "lblDataNascimentoPai";
            lblDataNascimentoPai.Size = new Size(136, 20);
            lblDataNascimentoPai.TabIndex = 13;
            lblDataNascimentoPai.Text = "Nascimento do Pai:";
            // 
            // lblDataNascimentoMae
            // 
            lblDataNascimentoMae.AutoSize = true;
            lblDataNascimentoMae.Location = new Point(315, 206);
            lblDataNascimentoMae.Margin = new Padding(2, 0, 2, 0);
            lblDataNascimentoMae.Name = "lblDataNascimentoMae";
            lblDataNascimentoMae.Size = new Size(64, 20);
            lblDataNascimentoMae.TabIndex = 15;
            lblDataNascimentoMae.Text = "Da Mãe:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(299, 246);
            btnCancelar.Margin = new Padding(2, 2, 2, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(92, 29);
            btnCancelar.TabIndex = 18;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // ObitoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 290);
            Controls.Add(btnCancelar);
            Controls.Add(lblDataNascimentoMae);
            Controls.Add(dtpDataNascimentoMae);
            Controls.Add(lblDataNascimentoPai);
            Controls.Add(dtpDataNascimentoPai);
            Controls.Add(lblNomeMae);
            Controls.Add(txtNomeMae);
            Controls.Add(lblNomePai);
            Controls.Add(txtNomePai);
            Controls.Add(lblDataNascimento);
            Controls.Add(dtpDataNascimento);
            Controls.Add(lblNomeFalecido);
            Controls.Add(txtNomeFalecido);
            Controls.Add(lblDataObito);
            Controls.Add(dtpDataObito);
            Controls.Add(lblDataRegistro);
            Controls.Add(dtpDataRegistro);
            Controls.Add(btnSalvar);
            Margin = new Padding(2, 2, 2, 2);
            Name = "ObitoForm";
            Text = "Cadastro de Óbitos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalvar;
        private DateTimePicker dtpDataRegistro;
        private DateTimePicker dtpDataObito;
        private TextBox txtNomeFalecido;
        private DateTimePicker dtpDataNascimento;
        private TextBox txtNomePai;
        private TextBox txtNomeMae;
        private DateTimePicker dtpDataNascimentoPai;
        private DateTimePicker dtpDataNascimentoMae;
        private Label lblDataRegistro;
        private Label lblDataObito;
        private Label lblNomeFalecido;
        private Label lblDataNascimento;
        private Label lblNomePai;
        private Label lblNomeMae;
        private Label lblDataNascimentoPai;
        private Label lblDataNascimentoMae;
        private Button btnCancelar;
    }
}