namespace AtosCartorio.Views
{
    partial class NascimentoForm
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSalvar = new Button();
            dtpDataRegistro = new DateTimePicker();
            dtpDataNascimento = new DateTimePicker();
            txtNomeRegistrado = new TextBox();
            txtNomePai = new TextBox();
            txtNomeMae = new TextBox();
            dtpDataNascimentoPai = new DateTimePicker();
            dtpDataNascimentoMae = new DateTimePicker();
            txtCpfPai = new TextBox();
            txtCpfMae = new TextBox();
            lblDataRegistro = new Label();
            lblDataNascimento = new Label();
            lblNomeRegistrado = new Label();
            lblNomePai = new Label();
            lblNomeMae = new Label();
            lblDataNascimentoPai = new Label();
            lblDataNascimentoMae = new Label();
            lblCpfPai = new Label();
            lblCpfMae = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(682, 391);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(150, 46);
            btnSalvar.TabIndex = 19;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += new EventHandler(btnSalvar_Click);
            // 
            // dtpDataRegistro
            // 
            dtpDataRegistro.Format = DateTimePickerFormat.Short;
            dtpDataRegistro.Location = new Point(282, 27);
            dtpDataRegistro.Name = "dtpDataRegistro";
            dtpDataRegistro.Size = new Size(200, 39);
            dtpDataRegistro.TabIndex = 2;
            // 
            // dtpDataNascimento
            // 
            dtpDataNascimento.Format = DateTimePickerFormat.Short;
            dtpDataNascimento.Location = new Point(282, 77);
            dtpDataNascimento.Name = "dtpDataNascimento";
            dtpDataNascimento.Size = new Size(200, 39);
            dtpDataNascimento.TabIndex = 4;
            // 
            // txtNomeRegistrado
            // 
            txtNomeRegistrado.Location = new Point(282, 127);
            txtNomeRegistrado.Name = "txtNomeRegistrado";
            txtNomeRegistrado.Size = new Size(550, 39);
            txtNomeRegistrado.TabIndex = 6;
            // 
            // txtNomePai
            // 
            txtNomePai.Location = new Point(282, 177);
            txtNomePai.Name = "txtNomePai";
            txtNomePai.Size = new Size(550, 39);
            txtNomePai.TabIndex = 8;
            // 
            // txtNomeMae
            // 
            txtNomeMae.Location = new Point(282, 227);
            txtNomeMae.Name = "txtNomeMae";
            txtNomeMae.Size = new Size(550, 39);
            txtNomeMae.TabIndex = 10;
            // 
            // dtpDataNascimentoPai
            // 
            dtpDataNascimentoPai.Format = DateTimePickerFormat.Short;
            dtpDataNascimentoPai.Location = new Point(282, 277);
            dtpDataNascimentoPai.Name = "dtpDataNascimentoPai";
            dtpDataNascimentoPai.ShowCheckBox = true;
            dtpDataNascimentoPai.Size = new Size(200, 39);
            dtpDataNascimentoPai.TabIndex = 12;
            // 
            // dtpDataNascimentoMae
            // 
            dtpDataNascimentoMae.Format = DateTimePickerFormat.Short;
            dtpDataNascimentoMae.Location = new Point(282, 327);
            dtpDataNascimentoMae.Name = "dtpDataNascimentoMae";
            dtpDataNascimentoMae.ShowCheckBox = true;
            dtpDataNascimentoMae.Size = new Size(200, 39);
            dtpDataNascimentoMae.TabIndex = 14;
            // 
            // txtCpfPai
            // 
            txtCpfPai.Location = new Point(632, 277);
            txtCpfPai.Name = "txtCpfPai";
            txtCpfPai.Size = new Size(200, 39);
            txtCpfPai.TabIndex = 16;
            // 
            // txtCpfMae
            // 
            txtCpfMae.Location = new Point(632, 327);
            txtCpfMae.Name = "txtCpfMae";
            txtCpfMae.Size = new Size(200, 39);
            txtCpfMae.TabIndex = 18;
            // 
            // lblDataRegistro
            // 
            lblDataRegistro.AutoSize = true;
            lblDataRegistro.Location = new Point(30, 30);
            lblDataRegistro.Name = "lblDataRegistro";
            lblDataRegistro.Size = new Size(195, 32);
            lblDataRegistro.TabIndex = 1;
            lblDataRegistro.Text = "Data de Registro:";
            // 
            // lblDataNascimento
            // 
            lblDataNascimento.AutoSize = true;
            lblDataNascimento.Location = new Point(30, 80);
            lblDataNascimento.Name = "lblDataNascimento";
            lblDataNascimento.Size = new Size(236, 32);
            lblDataNascimento.TabIndex = 3;
            lblDataNascimento.Text = "Data de Nascimento:";
            // 
            // lblNomeRegistrado
            // 
            lblNomeRegistrado.AutoSize = true;
            lblNomeRegistrado.Location = new Point(30, 130);
            lblNomeRegistrado.Name = "lblNomeRegistrado";
            lblNomeRegistrado.Size = new Size(239, 32);
            lblNomeRegistrado.TabIndex = 5;
            lblNomeRegistrado.Text = "Nome do Registrado:";
            // 
            // lblNomePai
            // 
            lblNomePai.AutoSize = true;
            lblNomePai.Location = new Point(30, 180);
            lblNomePai.Name = "lblNomePai";
            lblNomePai.Size = new Size(157, 32);
            lblNomePai.TabIndex = 7;
            lblNomePai.Text = "Nome do Pai:";
            // 
            // lblNomeMae
            // 
            lblNomeMae.AutoSize = true;
            lblNomeMae.Location = new Point(30, 230);
            lblNomeMae.Name = "lblNomeMae";
            lblNomeMae.Size = new Size(172, 32);
            lblNomeMae.TabIndex = 9;
            lblNomeMae.Text = "Nome da Mãe:";
            // 
            // lblDataNascimentoPai
            // 
            lblDataNascimentoPai.AutoSize = true;
            lblDataNascimentoPai.Location = new Point(30, 280);
            lblDataNascimentoPai.Name = "lblDataNascimentoPai";
            lblDataNascimentoPai.Size = new Size(218, 32);
            lblDataNascimentoPai.TabIndex = 11;
            lblDataNascimentoPai.Text = "Nascimento do Pai:";
            // 
            // lblDataNascimentoMae
            // 
            lblDataNascimentoMae.AutoSize = true;
            lblDataNascimentoMae.Location = new Point(30, 330);
            lblDataNascimentoMae.Name = "lblDataNascimentoMae";
            lblDataNascimentoMae.Size = new Size(233, 32);
            lblDataNascimentoMae.TabIndex = 13;
            lblDataNascimentoMae.Text = "Nascimento da Mãe:";
            // 
            // lblCpfPai
            // 
            lblCpfPai.AutoSize = true;
            lblCpfPai.Location = new Point(532, 277);
            lblCpfPai.Name = "lblCpfPai";
            lblCpfPai.Size = new Size(96, 32);
            lblCpfPai.TabIndex = 15;
            lblCpfPai.Text = "CPF Pai:";
            // 
            // lblCpfMae
            // 
            lblCpfMae.AutoSize = true;
            lblCpfMae.Location = new Point(532, 327);
            lblCpfMae.Name = "lblCpfMae";
            lblCpfMae.Size = new Size(113, 32);
            lblCpfMae.TabIndex = 17;
            lblCpfMae.Text = "CPF Mãe:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(495, 391);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 46);
            btnCancelar.TabIndex = 20;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
            // 
            // NascimentoForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 461);
            Controls.Add(btnCancelar);
            Controls.Add(lblCpfMae);
            Controls.Add(txtCpfMae);
            Controls.Add(lblCpfPai);
            Controls.Add(txtCpfPai);
            Controls.Add(lblDataNascimentoMae);
            Controls.Add(dtpDataNascimentoMae);
            Controls.Add(lblDataNascimentoPai);
            Controls.Add(dtpDataNascimentoPai);
            Controls.Add(lblNomeMae);
            Controls.Add(txtNomeMae);
            Controls.Add(lblNomePai);
            Controls.Add(txtNomePai);
            Controls.Add(lblNomeRegistrado);
            Controls.Add(txtNomeRegistrado);
            Controls.Add(lblDataNascimento);
            Controls.Add(dtpDataNascimento);
            Controls.Add(lblDataRegistro);
            Controls.Add(dtpDataRegistro);
            Controls.Add(btnSalvar);
            Name = "NascimentoForm";
            Text = "Cadastro de Nascimentos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalvar;
        private DateTimePicker dtpDataRegistro;
        private DateTimePicker dtpDataNascimento;
        private TextBox txtNomeRegistrado;
        private TextBox txtNomePai;
        private TextBox txtNomeMae;
        private DateTimePicker dtpDataNascimentoPai;
        private DateTimePicker dtpDataNascimentoMae;
        private TextBox txtCpfPai;
        private TextBox txtCpfMae;
        private Label lblDataRegistro;
        private Label lblDataNascimento;
        private Label lblNomeRegistrado;
        private Label lblNomePai;
        private Label lblNomeMae;
        private Label lblDataNascimentoPai;
        private Label lblDataNascimentoMae;
        private Label lblCpfPai;
        private Label lblCpfMae;
        private Button btnCancelar;
    }
}